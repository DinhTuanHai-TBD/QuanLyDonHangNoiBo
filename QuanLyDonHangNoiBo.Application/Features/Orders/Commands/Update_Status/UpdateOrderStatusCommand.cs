
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Update_Status;

public sealed record UpdateOrderStatusCommand(Guid OrderId, UpdateOrderStatusRequest Request);


