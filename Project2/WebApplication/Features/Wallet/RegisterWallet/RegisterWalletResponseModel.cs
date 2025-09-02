namespace WebApplication.Features.Wallet.RegisterWallet
{
    public partial class RegisterWalletController
    {
        public class RegisterWalletResponseModel : ResponseModel
        {
            public int WalletId { get; set; }
            public string WalletUserName { get; set; }
            public string FullName { get; set; }
            public string MobileNo { get; set; }
        }
    }
}
