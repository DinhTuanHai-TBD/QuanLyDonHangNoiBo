namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private ReturnRequest FindReturn(Guid returnId)
    {
        var returnRequest = _repository.Returns.FirstOrDefault(item => item.Id == returnId)
            ?? throw new KeyNotFoundException("Phieu hoan hang khong ton tai.");
        EnsureCanAccessTenant(returnRequest.TenantId);
        return returnRequest;
    }
}

