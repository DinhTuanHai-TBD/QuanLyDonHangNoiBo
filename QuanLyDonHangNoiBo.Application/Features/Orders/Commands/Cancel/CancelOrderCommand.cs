
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Cancel;

public sealed record CancelOrderCommand(Guid OrderId, string Note, Guid? UserId);


