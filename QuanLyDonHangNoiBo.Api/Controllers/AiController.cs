using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/ai")]
public sealed class AiController : ApiControllerBase
{
    public AiController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpPost("chat")]
    [Authorize(Policy = PermissionPolicies.AiAsk)]
    public ActionResult<AiChatResponse> AskAi(AiChatRequest request)
    {
        return Execute(() => Service.AskAi(request));
    }
}




