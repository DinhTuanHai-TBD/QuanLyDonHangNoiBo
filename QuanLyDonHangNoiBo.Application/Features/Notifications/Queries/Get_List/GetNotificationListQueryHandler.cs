
namespace QuanLyDonHangNoiBo.Application.Features.Notifications.Queries.Get_List;

public sealed class GetNotificationListQueryHandler
{
    private readonly OmsApplicationService _service;

    public GetNotificationListQueryHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public IReadOnlyList<NotificationDto> Handle(GetNotificationListQuery query)
    {
        return _service.GetNotifications(query.TenantId);
    }
}


