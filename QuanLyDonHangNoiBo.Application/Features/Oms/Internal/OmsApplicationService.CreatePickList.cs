namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public PickListDto CreatePickList(CreatePickListRequest request)
    {
        var order = FindOrder(request.OrderId);
        if (_repository.PickLists.Any(item => item.OrderId == order.Id && item.Status != PickListStatus.Cancelled))
        {
            throw new InvalidOperationException("Don hang da co pick list dang hoat dong.");
        }

        if (order.Status == OrderStatus.Draft)
        {
            UpdateOrderStatusInternal(order.Id, OrderStatus.Confirmed, "Auto confirm before pick list", request.AssignedToUserId, null);
        }

        var pickList = new PickList
        {
            TenantId = order.TenantId,
            OrderId = order.Id,
            WarehouseId = order.WarehouseId,
            AssignedToUserId = request.AssignedToUserId,
            PickListCode = $"PICK-{DateTimeOffset.UtcNow:yyMMdd}-{_repository.PickLists.Count(item => item.TenantId == order.TenantId) + 1:0000}",
            Status = PickListStatus.Open,
            CreatedAt = DateTimeOffset.UtcNow
        };

        foreach (var orderItem in order.Items)
        {
            var sku = _repository.Skus.First(item => item.Id == orderItem.SkuId);
            pickList.Items.Add(new PickListItem
            {
                PickListId = pickList.Id,
                SkuId = orderItem.SkuId,
                SkuCode = orderItem.SkuCode,
                Barcode = sku.Barcode,
                ProductName = orderItem.ProductName,
                RequiredQuantity = orderItem.Quantity,
                PickedQuantity = 0
            });
        }

        _repository.AddPickList(pickList);
        UpdateOrderStatusInternal(order.Id, OrderStatus.Picking, "Create pick list", request.AssignedToUserId, null);
        _repository.AddAuditLog(new AuditLog
        {
            TenantId = order.TenantId,
            UserId = request.AssignedToUserId,
            EntityName = nameof(PickList),
            EntityId = pickList.Id.ToString(),
            Action = "CreatePickList",
            AfterValue = pickList.PickListCode
        });

        return ToPickListDto(pickList);
    }
}

