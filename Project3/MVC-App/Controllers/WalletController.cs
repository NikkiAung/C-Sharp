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

    }

    public class WalletModel
    {
        public string WalletUserName { get; set; }
        public string FullName { get; set; }
        public string MobileNo { get; set; }
        public decimal Balance { get; set; }
    }
    
    
}
