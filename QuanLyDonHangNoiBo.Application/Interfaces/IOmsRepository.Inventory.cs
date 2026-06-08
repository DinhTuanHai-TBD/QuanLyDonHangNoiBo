
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<InventoryStock> InventoryStocks { get; }
    IReadOnlyList<InventoryTransaction> InventoryTransactions { get; }
    InventoryStock AddInventoryStock(InventoryStock stock);
    InventoryTransaction AddInventoryTransaction(InventoryTransaction transaction);
}

