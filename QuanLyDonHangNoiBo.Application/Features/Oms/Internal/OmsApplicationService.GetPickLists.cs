namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<PickListDto> GetPickLists(Guid? tenantId, PickListStatus? status)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.PickLists.Where(item => item.TenantId == resolvedTenantId);
        if (status.HasValue)
        {
            query = query.Where(item => item.Status == status.Value);
        }

        return query.OrderByDescending(item => item.CreatedAt).Select(ToPickListDto).ToList();
    }
}

