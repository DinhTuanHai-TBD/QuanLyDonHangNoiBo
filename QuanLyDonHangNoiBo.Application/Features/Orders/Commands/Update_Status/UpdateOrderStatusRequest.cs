namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Update_Status;

public sealed record UpdateOrderStatusRequest(OrderStatus Status, string Note, Guid? UserId);


