namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Commands.Upload_Pod;

public sealed class UploadProofOfDeliveryRequest
{
    public string ImageUrl { get; set; } = "";
    public string ReceiverName { get; set; } = "";
    public string Note { get; set; } = "";
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public decimal? CollectedAmount { get; set; }
    public Guid? UserId { get; set; }
}


