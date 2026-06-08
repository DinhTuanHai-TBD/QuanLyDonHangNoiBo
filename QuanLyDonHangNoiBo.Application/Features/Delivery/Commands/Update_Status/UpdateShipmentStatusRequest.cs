namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Commands.Update_Status;

public sealed record UpdateShipmentStatusRequest(ShipmentStatus Status, string Note, decimal? CollectedAmount);


