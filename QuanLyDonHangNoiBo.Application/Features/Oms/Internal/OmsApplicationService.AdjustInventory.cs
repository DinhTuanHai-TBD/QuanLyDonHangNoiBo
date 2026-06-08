namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public InventoryStockDto AdjustInventory(InventoryMutationRequest request)
    {
        return ChangeInventory(request, InventoryTransactionType.Adjustment);
    }
}

