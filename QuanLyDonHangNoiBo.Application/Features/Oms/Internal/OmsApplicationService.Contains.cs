namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static bool Contains(string source, string search)
    {
        return source.Contains(search, StringComparison.OrdinalIgnoreCase);
    }
}

