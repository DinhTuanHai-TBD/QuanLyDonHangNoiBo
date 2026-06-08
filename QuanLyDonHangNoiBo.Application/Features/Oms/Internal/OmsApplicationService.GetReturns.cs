namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public IReadOnlyList<ReturnDto> GetReturns(Guid? tenantId, ReturnStatus? status)
    {
        var resolvedTenantId = ResolveTenantId(tenantId);
        var query = _repository.Returns.Where(item => item.TenantId == resolvedTenantId);
        if (status.HasValue)
        {
            query = query.Where(item => item.Status == status.Value);
        }

        return query.OrderByDescending(item => item.CreatedAt).Select(ToReturnDto).ToList();
    }
}

