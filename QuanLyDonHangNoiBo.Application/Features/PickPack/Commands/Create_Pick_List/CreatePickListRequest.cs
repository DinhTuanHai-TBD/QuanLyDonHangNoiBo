namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Commands.Create_Pick_List;

public sealed class CreatePickListRequest
{
    public Guid OrderId { get; set; }
    public Guid? AssignedToUserId { get; set; }
}


