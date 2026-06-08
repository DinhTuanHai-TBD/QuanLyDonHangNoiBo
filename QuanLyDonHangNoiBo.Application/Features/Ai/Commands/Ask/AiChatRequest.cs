namespace QuanLyDonHangNoiBo.Application.Features.Ai.Commands.Ask;

public sealed record AiChatRequest(Guid? TenantId, string Question, Guid? UserId);


