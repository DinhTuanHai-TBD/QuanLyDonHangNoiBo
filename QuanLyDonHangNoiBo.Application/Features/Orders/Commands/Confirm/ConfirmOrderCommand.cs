
namespace QuanLyDonHangNoiBo.Application.Features.Orders.Commands.Confirm;

public sealed record ConfirmOrderCommand(Guid OrderId, Guid? UserId);


