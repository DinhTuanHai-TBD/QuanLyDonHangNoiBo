namespace QuanLyDonHangNoiBo.Application.Features.Ai.Common;

public sealed record AiChatResponse(string Answer, IReadOnlyList<RelatedLinkDto> RelatedLinks, IReadOnlyList<string> SuggestedQuestions);


