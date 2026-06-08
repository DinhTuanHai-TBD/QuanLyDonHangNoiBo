
namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Queries.Get_Packages;

public sealed class GetPackageListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetPackageListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<PackageDto> Handle(GetPackageListQuery query)
    {
        return _service.GetPackages(query.TenantId, query.OrderId);
    }
}


