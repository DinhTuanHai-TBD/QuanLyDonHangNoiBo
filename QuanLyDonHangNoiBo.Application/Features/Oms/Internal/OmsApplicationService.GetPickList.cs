namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public PickListDto GetPickList(Guid pickListId)
    {
        return ToPickListDto(FindPickList(pickListId));
    }
}

