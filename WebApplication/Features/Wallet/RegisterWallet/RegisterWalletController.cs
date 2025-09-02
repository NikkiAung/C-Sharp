
using DataBases.AppDbContextModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Features.Wallet.RegisterWallet
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class RegisterWalletController : ControllerBase
    {

        private readonly AppDbContext _appDbContext;

        public RegisterWalletController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public IActionResult Execute(RegisterWalletRequestModel requestModel)
        {
            RegisterWalletResponseModel model;
            
            #region Check Required Fields
            if (string.IsNullOrEmpty(requestModel.WalletUserName))
            {
                model = new RegisterWalletResponseModel
                {
                    IsSuccess = false,
                    Message = "Wallet user name is required."
                };
                goto Result;
            }
            
            if (string.IsNullOrEmpty(requestModel.FullName))
            {
                model = new RegisterWalletResponseModel
                {
                    IsSuccess = false,
                    Message = "FullName is required."
                };
                goto Result;
            }

            if (string.IsNullOrEmpty(requestModel.MobileNo))
            {
                model = new RegisterWalletResponseModel
                {
                    IsSuccess = false,
                    Message = "Mobile Number is required."
                };
                goto Result;
            }
            #endregion

            #region check Duplicate wallet user name
            var existUserName = _appDbContext.TblWallets
                .FirstOrDefault(x => x.WallletUserName == requestModel.WalletUserName);

            if (existUserName != null)
            {
                model = new RegisterWalletResponseModel
                {
                    IsSuccess = false,
                    Message = "Wallet user name is already exist."
                };
                goto Result;
            }   

            if (requestModel.MobileNo.Length != 10)
            {
                model = new RegisterWalletResponseModel
                {
                    IsSuccess = false,
                    Message = "Mobile number must be 10 digits."
                };
                goto Result;
            }
            #endregion


            #region Register Wallet
            TblWallet item = new TblWallet
            {
                Balance = 0,
                FullName = requestModel.FullName,
                MobileNo = requestModel.MobileNo,
                WallletUserName = requestModel.WalletUserName
            };
            _appDbContext.TblWallets.Add(item);
            _appDbContext.SaveChanges();
            #endregion

            model = new RegisterWalletResponseModel
            {
                FullName = item.FullName,
                MobileNo = item.MobileNo,
                WalletId = item.WalletId,
                WalletUserName = item.WallletUserName,
                IsSuccess = true,
                Message = "Wallet registered successfully."
            };
            Result:
                return Ok(model);
        }
    }
}
