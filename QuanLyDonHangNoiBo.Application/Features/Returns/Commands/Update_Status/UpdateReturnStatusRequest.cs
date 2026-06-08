namespace QuanLyDonHangNoiBo.Application.Features.Returns.Commands.Update_Status;

public sealed record UpdateReturnStatusRequest(ReturnStatus Status, string Note, Guid? UserId);


