namespace QuanLyDonHangNoiBo.Api.Security;

public sealed class JwtOptions
{
    public const string SectionName = "Jwt";

    public string Issuer { get; init; } = "QuanLyDonHangNoiBo.Api";

    public string Audience { get; init; } = "QuanLyDonHangNoiBo.Client";

    public string SigningKey { get; init; } = "CHANGE_ME_TO_A_LONG_RANDOM_SECRET_KEY_32+";

    public int AccessTokenMinutes { get; init; } = 120;
}
