using System.Data;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

namespace MVC_App.Controllers
{
    public class WalletController : Controller
    {
        // GET: BlogController

        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "MiniWallet",
            UserID = "sa",
            Password = "CodeWithArjun123",
            TrustServerCertificate = true
        };
        [ActionName("Index")]
        public async Task<ActionResult> WalletIndexAsync()
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();
            var lst = await db.QueryAsync<WalletModel>("SELECT * FROM tbl_wallet");

            return View("WalletIndex", lst.ToList());
        }

        [ActionName("Create")]
        public ActionResult WallletCreate()
        {
            return View("WalletCreate");
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult WallletCreate(WalletModel requestModel)
        {
            return View("WalletCreate");
        }


        [HttpPost]
        [ActionName("Save")]
        public async Task<IActionResult> WalletCreateAsync(WalletModel requestModel)
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            string query = @"INSERT INTO [dbo].[Tbl_Wallet]
            ([WalletUserName]
            ,[FullName]
            ,[MobileNo]
            ,[Balance])
        VALUES
            (@WalletUserName
            ,@FullName
            ,@MobileNo
            ,@Balance)";



            var res = await db.ExecuteAsync(query, requestModel);
            bool isSuccess = res > 0;
            string message = isSuccess ? "Success" : "Fail";
            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Edit")]
        public async Task<IActionResult> WalletEditAsync(int walletId)
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            string query = @"SELECT * FROM [dbo].[Tbl_Wallet] WHERE WalletId = @WalletId";


            var model = await db.QueryFirstOrDefaultAsync<WalletModel>(
                query,
                new { WalletId = walletId });

            if (model is null)
            {
                TempData["IsSuccess"] = false;
                TempData["Message"] = "No data found.";
                return RedirectToAction("Index");
            }

            return View("WalletEdit", model);
        }

        [HttpPost]
        [ActionName("Update")]
        public async Task<IActionResult> WalletUpdateAsync(int walletId, WalletModel requestModel)
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            string query = @"UPDATE [dbo].[Tbl_Wallet]
            SET 
                [WalletUserName] = @WalletUserName
                ,[FullName] = @FullName
                ,[MobileNo] = @MobileNo
                ,[Balance] = @Balance
            WHERE WalletId = @WalletId";

            var res = await db.ExecuteAsync(query, new { requestModel.WalletUserName, requestModel.FullName, requestModel.MobileNo, requestModel.Balance, WalletId = walletId });
            bool isSuccess = res > 0;
            string message = isSuccess ? "Update Success" : "Update Fail";
            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }
        // http://localhost:5105/Wallet/Edit?walletId=1
        // http://localhost:5105/Wallet/Delete?walletId=1
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> WalletDeleteAsync(int walletId)
        {
            using IDbConnection db = new SqlConnection(builder.ConnectionString);
            db.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Wallet] WHERE WalletId = @WalletId";

            var res = await db.ExecuteAsync(query, new { WalletId = walletId });
            bool isSuccess = res > 0;
            string message = isSuccess ? "Delete Success" : "Delete Fail";
            TempData["IsSuccess"] = isSuccess;
            TempData["Message"] = message;
            return RedirectToAction("Index");
        }
    }

    public class WalletModel
        {
            public int WalletId { get; set; }
            public string WalletUserName { get; set; }
            public string FullName { get; set; }
            public string MobileNo { get; set; }
            public decimal Balance { get; set; }
        }
}


// '/Users/aungnandaoo/Desktop/C-Program/Project3/MVC-App/MVC-App.csproj' failed to build. Would you like to continue and run the last successful build?