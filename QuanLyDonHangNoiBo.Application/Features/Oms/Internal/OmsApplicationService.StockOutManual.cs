namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public InventoryStockDto StockOutManual(InventoryMutationRequest request)
    {
        return ChangeInventory(request, InventoryTransactionType.StockOut);
    }
}

