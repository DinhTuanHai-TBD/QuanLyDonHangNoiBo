namespace QuanLyDonHangNoiBo.Application.Features.Dashboard.Common;

public sealed record DashboardDto(
    IReadOnlyList<KpiDto> Kpis,
    IReadOnlyList<StatusMetricDto> StatusBreakdown,
    IReadOnlyList<OrderSummaryDto> RecentOrders,
    IReadOnlyList<OperationalAlertDto> Alerts,
    IReadOnlyList<AiInsightDto> AiInsights,
    IReadOnlyList<PipelineColumnDto> Pipeline);


