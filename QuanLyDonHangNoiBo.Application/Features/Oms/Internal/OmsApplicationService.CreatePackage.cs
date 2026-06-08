namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public PackageDto CreatePackage(CreatePackageRequest request)
    {
        var order = FindOrder(request.OrderId);
        var pickList = _repository.PickLists.FirstOrDefault(item => item.OrderId == order.Id && item.Status != PickListStatus.Cancelled);
        if (pickList is not null && pickList.Status != PickListStatus.Completed)
        {
            throw new InvalidOperationException("Pick list chua hoan tat, chua the dong goi.");
        }

        var package = new Package
        {
            TenantId = order.TenantId,
            OrderId = order.Id,
            PackageCode = $"PKG-{DateTimeOffset.UtcNow:yyMMdd}-{_repository.Packages.Count(item => item.TenantId == order.TenantId) + 1:0000}",
            WeightKg = Math.Max(0, request.WeightKg),
            LengthCm = Math.Max(0, request.LengthCm),
            WidthCm = Math.Max(0, request.WidthCm),
            HeightCm = Math.Max(0, request.HeightCm),
            LabelUrl = $"/labels/{order.OrderCode}.pdf",
            Status = request.MarkReadyToShip ? PackageStatus.ReadyToShip : PackageStatus.Created,
            CreatedAt = DateTimeOffset.UtcNow
        };

        _repository.AddPackage(package);
        UpdateOrderStatusInternal(order.Id, OrderStatus.Packed, "Package created", null, null);
        if (request.MarkReadyToShip)
        {
            UpdateOrderStatusInternal(order.Id, OrderStatus.ReadyToShip, "Package ready to ship", null, null);
        }

        _repository.AddAuditLog(new AuditLog
        {
            TenantId = order.TenantId,
            EntityName = nameof(Package),
            EntityId = package.Id.ToString(),
            Action = "CreatePackage",
            AfterValue = package.PackageCode
        });

        return ToPackageDto(package);
    }
}

