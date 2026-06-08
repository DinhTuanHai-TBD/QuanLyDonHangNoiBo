namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public InventoryStockDto StockIn(InventoryMutationRequest request)
    {
        return ChangeInventory(request, InventoryTransactionType.StockIn);
    }
}

