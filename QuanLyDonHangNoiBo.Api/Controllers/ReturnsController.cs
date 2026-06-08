using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/returns")]
public sealed class ReturnsController : ApiControllerBase
{
    public ReturnsController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.ReturnsManage)]
    public ActionResult<IReadOnlyList<ReturnDto>> GetReturns([FromQuery] Guid? tenantId, [FromQuery] ReturnStatus? status)
    {
        return Execute(() => Service.GetReturns(tenantId, status));
    }

    [HttpGet("{returnId:guid}")]
    [Authorize(Policy = PermissionPolicies.ReturnsManage)]
    public ActionResult<ReturnDto> GetReturn(Guid returnId)
    {
        return Execute(() => Service.GetReturn(returnId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.ReturnsManage)]
    public ActionResult<ReturnDto> CreateReturn(CreateReturnRequest request)
    {
        return Execute(() => Service.CreateReturn(request));
    }

    [HttpPost("{returnId:guid}/status")]
    [Authorize(Policy = PermissionPolicies.ReturnsManage)]
    public ActionResult<ReturnDto> UpdateReturnStatus(Guid returnId, UpdateReturnStatusRequest request)
    {
        return Execute(() => Service.UpdateReturnStatus(returnId, request));
    }
}





