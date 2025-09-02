using System;
using System.Collections.Generic;

namespace DataBases.AppDbContextModels;

public partial class TblWallletHistory
{
    public int WalletHistoryId { get; set; }

    public string MobileNo { get; set; } = null!;

    public string TransactionType { get; set; } = null!;

    public decimal Amount { get; set; }
}
