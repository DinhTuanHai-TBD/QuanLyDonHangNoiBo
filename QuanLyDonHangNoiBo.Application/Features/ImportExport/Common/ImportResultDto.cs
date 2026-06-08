namespace QuanLyDonHangNoiBo.Application.Features.ImportExport.Common;

public sealed record ImportResultDto(int SuccessCount, int FailedCount, IReadOnlyList<string> Errors);


