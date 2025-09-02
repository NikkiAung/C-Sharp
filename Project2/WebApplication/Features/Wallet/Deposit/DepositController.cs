using DataBases.AppDbContextModels;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Features.Wallet.RegisterWallet;
using WebApplication.Features.Wallet;

namespace WebApplication.Features.Wallet.Deposit
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public DepositController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(DepositRequestModel requestModel)
        {
            DepositResponseModel model;
            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new DepositResponseModel
                {
                    IsSuccess = false,
                    Message = "Mobile Number is required."
                };
                goto Result;
            }

            if (requestModel.Amount <= 0)
            {
                model = new DepositResponseModel
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
                model = new DepositResponseModel
                {
                    IsSuccess = false,
                    Message = "Wallet not found."
                };
                goto Result;
            }

            decimal oldBalance = itemWallet.Balance;
            decimal newBalance = oldBalance + requestModel.Amount;

            itemWallet.Balance = newBalance;
            _appDbContext.SaveChanges();

            _appDbContext.TblWallletHistories.Add(new TblWallletHistory
            {
                Amount = requestModel.Amount,
                MobileNo = requestModel.MobileNo,
                TransactionType = "Deposit"
            });

            model = new DepositResponseModel
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

    public class DepositRequestModel
    {
        public required string MobileNo { get; set; }
        public decimal Amount { get; set; }
    }

    public class DepositResponseModel : ResponseModel
    {
        public decimal OldBalance { get; set; }
        public decimal NewBalance { get; set; }
    }
}
