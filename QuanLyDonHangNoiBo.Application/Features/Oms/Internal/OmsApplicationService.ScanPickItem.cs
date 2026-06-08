namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public PickListDto ScanPickItem(Guid pickListId, ScanPickItemRequest request)
    {
        var pickList = FindPickList(pickListId);
        if (pickList.Status is PickListStatus.Completed or PickListStatus.Cancelled)
        {
            throw new InvalidOperationException("Pick list da ket thuc, khong the scan tiep.");
        }

        if (request.Quantity <= 0)
        {
            throw new InvalidOperationException("So luong scan phai lon hon 0.");
        }

        var item = pickList.Items.FirstOrDefault(pickItem =>
            (request.SkuId.HasValue && pickItem.SkuId == request.SkuId.Value) ||
            (!string.IsNullOrWhiteSpace(request.SkuCode) && pickItem.SkuCode.Equals(request.SkuCode.Trim(), StringComparison.OrdinalIgnoreCase)) ||
            (!string.IsNullOrWhiteSpace(request.Barcode) && pickItem.Barcode.Equals(request.Barcode.Trim(), StringComparison.OrdinalIgnoreCase)))
            ?? throw new InvalidOperationException("Barcode/SKU khong thuoc pick list.");

        var remaining = item.RequiredQuantity - item.PickedQuantity;
        if (request.Quantity > remaining)
        {
            throw new InvalidOperationException($"So luong scan vuot qua can pick. Con lai {remaining}.");
        }

        pickList.Status = PickListStatus.Picking;
        item.PickedQuantity += request.Quantity;

        if (pickList.Items.All(pickItem => pickItem.IsCompleted))
        {
            pickList.Status = PickListStatus.Completed;
            pickList.CompletedAt = DateTimeOffset.UtcNow;
        }

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = pickList.TenantId,
            EntityName = nameof(PickListItem),
            EntityId = item.Id.ToString(),
            Action = "ScanPickItem",
            AfterValue = $"{item.SkuCode}:{item.PickedQuantity}/{item.RequiredQuantity}"
        });

        return ToPickListDto(pickList);
    }
}

