namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Common;

public sealed record PipelineColumnDto(string Status, int Count, IReadOnlyList<OrderSummaryDto> Orders);


