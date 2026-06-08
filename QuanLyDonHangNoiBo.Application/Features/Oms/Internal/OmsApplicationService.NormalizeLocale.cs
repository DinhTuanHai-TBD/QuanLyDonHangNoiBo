namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static string NormalizeLocale(string locale)
    {
        var value = string.IsNullOrWhiteSpace(locale) ? "vi" : locale.Trim().ToLowerInvariant();
        return value.Length > 8 ? value[..8] : value;
    }
}

