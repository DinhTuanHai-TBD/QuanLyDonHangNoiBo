namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private readonly IOmsRepository _repository;
    private readonly QuanLyDonHangNoiBo.Application.Common.Security.ICurrentUserContext _currentUser;

    public OmsApplicationService(IOmsRepository repository, QuanLyDonHangNoiBo.Application.Common.Security.ICurrentUserContext currentUser)
    {
        _repository = repository;
        _currentUser = currentUser;
    }
}

