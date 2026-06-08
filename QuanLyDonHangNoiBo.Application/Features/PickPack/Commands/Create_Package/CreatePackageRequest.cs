namespace QuanLyDonHangNoiBo.Application.Features.PickPack.Commands.Create_Package;

public sealed class CreatePackageRequest
{
    public Guid OrderId { get; set; }
    public decimal WeightKg { get; set; }
    public decimal LengthCm { get; set; }
    public decimal WidthCm { get; set; }
    public decimal HeightCm { get; set; }
    public bool MarkReadyToShip { get; set; }
}


