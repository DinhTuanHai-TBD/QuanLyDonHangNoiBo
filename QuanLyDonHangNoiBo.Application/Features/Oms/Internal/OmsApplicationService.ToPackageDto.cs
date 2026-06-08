namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private PackageDto ToPackageDto(Package package)
    {
        var order = FindOrder(package.OrderId);
        return new PackageDto(package.Id, package.TenantId, order.Id, order.OrderCode, package.PackageCode, package.WeightKg, package.LengthCm, package.WidthCm, package.HeightCm, package.LabelUrl, package.Status, package.CreatedAt);
    }
}

