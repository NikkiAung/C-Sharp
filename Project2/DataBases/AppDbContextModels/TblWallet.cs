using System;
using System.Collections.Generic;

namespace DataBases.AppDbContextModels;

public partial class TblWallet
{
    public int WalletId { get; set; }

    public string WallletUserName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public decimal Balance { get; set; }
}
