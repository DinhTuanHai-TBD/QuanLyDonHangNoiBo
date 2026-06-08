namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    public ReturnDto GetReturn(Guid returnId)
    {
        return ToReturnDto(FindReturn(returnId));
    }
}

