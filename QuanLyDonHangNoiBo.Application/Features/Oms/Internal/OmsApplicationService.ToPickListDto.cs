namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private PickListDto ToPickListDto(PickList pickList)
    {
        var order = FindOrder(pickList.OrderId);
        var warehouse = _repository.Warehouses.First(item => item.Id == pickList.WarehouseId);
        var assignee = pickList.AssignedToUserId.HasValue
            ? _repository.Users.FirstOrDefault(item => item.Id == pickList.AssignedToUserId.Value)
            : null;

        return new PickListDto(
            pickList.Id,
            pickList.TenantId,
            order.Id,
            order.OrderCode,
            warehouse.Id,
            warehouse.Code,
            pickList.AssignedToUserId,
            assignee?.FullName ?? "Chua gan",
            pickList.PickListCode,
            pickList.Status,
            pickList.CreatedAt,
            pickList.CompletedAt,
            pickList.Items.Select(item => new PickListItemDto(item.Id, item.SkuId, item.SkuCode, item.Barcode, item.ProductName, item.RequiredQuantity, item.PickedQuantity, item.IsCompleted)).ToList());
    }
}

