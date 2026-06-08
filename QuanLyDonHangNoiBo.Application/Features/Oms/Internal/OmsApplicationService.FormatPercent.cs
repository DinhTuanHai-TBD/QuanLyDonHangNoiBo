namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static string FormatPercent(decimal value)
    {
        return $"{value:P0}";
    }
}

