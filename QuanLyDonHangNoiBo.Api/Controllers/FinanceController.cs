using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/cod")]
public sealed class FinanceController : ApiControllerBase
{
    public FinanceController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet("collections")]
    [Authorize(Policy = PermissionPolicies.CodRead)]
    public ActionResult<IReadOnlyList<CodCollectionDto>> GetCodCollections([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetCodCollections(tenantId));
    }

    [HttpPost("reconcile")]
    [Authorize(Policy = PermissionPolicies.CodReconcile)]
    public ActionResult<IReadOnlyList<CodCollectionDto>> ReconcileCodCollections(ReconcileCodRequest request)
    {
        return Execute(() => Service.ReconcileCodCollections(request));
    }
}





