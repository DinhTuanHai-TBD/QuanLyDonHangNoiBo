namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private PickList FindPickList(Guid pickListId)
    {
        var pickList = _repository.PickLists.FirstOrDefault(item => item.Id == pickListId)
            ?? throw new KeyNotFoundException("Pick list khong ton tai.");
        EnsureCanAccessTenant(pickList.TenantId);
        return pickList;
    }
}

