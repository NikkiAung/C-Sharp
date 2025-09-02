using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataBases.AppDbContextModels;
using WebApplication.Features.Wallet.RegisterWallet;
using System.Runtime.CompilerServices;

namespace WebApplication.Features.Wallet.Withdraw
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {   
        private readonly AppDbContext _appDbContext;
        private readonly decimal _miniAmount;
        private readonly IConfiguration _configuration;

        public WithdrawController(AppDbContext appDbContext, IConfiguration configuration)
        {
            _appDbContext = appDbContext;
            _configuration = configuration;
            _miniAmount = Convert.ToDecimal(_configuration.GetSection("MinAmount").Value);
        }

        [HttpPost]
        public IActionResult Execute(WithdrawRequestModel requestModel)
        {
            WithdrawResponseModel model;
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new WithdrawResponseModel
                {
                    IsSuccess = false,
                    Message = "Mobile Number is required."
                };
                goto Result;
            }

            if (requestModel.Amount <= 0)
            {
                model = new WithdrawResponseModel
                {
                    IsSuccess = false,
                    Message = "Amount must be greater than zero."
                };
                goto Result;
            }

            var itemWallet = _appDbContext.TblWallets
                .FirstOrDefault(x => x.MobileNo == requestModel.MobileNo);

            if (itemWallet is null)
            {
                model = new WithdrawResponseModel
                {
                    IsSuccess = false,
                    Message = "Wallet not found."
                };
                goto Result;
            }

            decimal oldBalance = itemWallet.Balance;

            if (oldBalance - _miniAmount < requestModel.Amount)
            {
                model = new WithdrawResponseModel
                {
                    IsSuccess = false,
                    Message = $"Insufficient amount. Minimum Amount must be {_miniAmount.ToString("n2")}"
                };
                goto Result;
            }

            decimal newBalance = oldBalance - requestModel.Amount;

            itemWallet.Balance = newBalance;

            _appDbContext.TblWallletHistories.Add(new TblWallletHistory
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                TransactionType = "Withdraw"
            });

            _appDbContext.SaveChanges();
            model = new WithdrawResponseModel
            {
                IsSuccess = true,
                Message = $"Deposit Amount - {requestModel.Amount}.",
                OldBalance = oldBalance,
                NewBalance = newBalance
            };

        Result:
            return Ok(model);
        }

    }

    public class WithdrawRequestModel
    {
        public string MobileNo { get; set; }
        public decimal Amount { get; set; }
    }

    public class WithdrawResponseModel : ResponseModel
    {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
}
