
namespace QuanLyDonHangNoiBo.Application.Features.Ai.Commands.Ask;

public sealed class AskAiCommandHandler
{
    private readonly OmsApplicationService _service;

    public AskAiCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public AiChatResponse Handle(AskAiCommand command)
    {
        return _service.AskAi(command.Request);
    }
}


