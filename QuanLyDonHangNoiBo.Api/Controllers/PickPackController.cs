using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Hubs;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class PickPackController : ApiControllerBase
{
    private readonly IHubContext<OrderHub> _orderHub;

    public PickPackController(OmsApplicationService service, IHubContext<OrderHub> orderHub)
        : base(service)
    {
        _orderHub = orderHub;
    }

    [HttpGet("picklists")]
    [Authorize(Policy = PermissionPolicies.PickPackManage)]
    public ActionResult<IReadOnlyList<PickListDto>> GetPickLists([FromQuery] Guid? tenantId, [FromQuery] PickListStatus? status)
    {
        return Execute(() => Service.GetPickLists(tenantId, status));
    }

    [HttpGet("picklists/{pickListId:guid}")]
    [Authorize(Policy = PermissionPolicies.PickPackManage)]
    public ActionResult<PickListDto> GetPickList(Guid pickListId)
    {
        return Execute(() => Service.GetPickList(pickListId));
    }

    [HttpPost("picklists")]
    [Authorize(Policy = PermissionPolicies.PickPackManage)]
    public async Task<ActionResult<PickListDto>> CreatePickList(CreatePickListRequest request)
    {
        var pickList = Service.CreatePickList(request);
        await _orderHub.Clients.Group($"warehouse:{pickList.TenantId}:{pickList.WarehouseId}").SendAsync("OrderAssignedToWarehouse", pickList);
        await _orderHub.Clients.Group($"tenant:{pickList.TenantId}").SendAsync("PickListCreated", pickList);
        return Ok(pickList);
    }

    [HttpPost("picklists/{pickListId:guid}/scan")]
    [Authorize(Policy = PermissionPolicies.PickPackManage)]
    public ActionResult<PickListDto> ScanPickItem(Guid pickListId, ScanPickItemRequest request)
    {
        return Execute(() => Service.ScanPickItem(pickListId, request));
    }

    [HttpGet("packages")]
    [Authorize(Policy = PermissionPolicies.PickPackManage)]
    public ActionResult<IReadOnlyList<PackageDto>> GetPackages([FromQuery] Guid? tenantId, [FromQuery] Guid? orderId)
    {
        return Execute(() => Service.GetPackages(tenantId, orderId));
    }

    [HttpPost("packages")]
    [Authorize(Policy = PermissionPolicies.PickPackManage)]
    public async Task<ActionResult<PackageDto>> CreatePackage(CreatePackageRequest request)
    {
        var package = Service.CreatePackage(request);
        await _orderHub.Clients.Group($"tenant:{package.TenantId}").SendAsync("PackageCreated", package);
        return Ok(package);
    }
}





