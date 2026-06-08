namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Common;

public sealed record KpiDto(string Key, string Label, string Value, string Tone, decimal Delta);


