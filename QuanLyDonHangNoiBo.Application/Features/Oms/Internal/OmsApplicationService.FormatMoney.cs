namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static string FormatMoney(decimal value)
    {
        return $"{value:N0} d";
    }
}

