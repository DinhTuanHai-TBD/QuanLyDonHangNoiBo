namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static AiInsightDto ToAiInsightDto(AiInsight insight)
    {
        return new AiInsightDto(insight.Id, insight.Title, insight.Summary, insight.Severity, insight.Link, insight.CreatedAt);
    }
}

