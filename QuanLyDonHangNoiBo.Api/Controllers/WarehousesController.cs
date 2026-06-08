using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/warehouses")]
public sealed class WarehousesController : ApiControllerBase
{
    public WarehousesController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.WarehousesManage)]
    public ActionResult<IReadOnlyList<WarehouseDto>> GetWarehouses([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetWarehouses(tenantId));
    }

    [HttpGet("{warehouseId:guid}")]
    [Authorize(Policy = PermissionPolicies.WarehousesManage)]
    public ActionResult<WarehouseDto> GetWarehouse(Guid warehouseId)
    {
        return Execute(() => Service.GetWarehouse(warehouseId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.WarehousesManage)]
    public ActionResult<WarehouseDto> CreateWarehouse(CreateWarehouseRequest request)
    {
        return Execute(() => Service.CreateWarehouse(request));
    }

    [HttpPut("{warehouseId:guid}")]
    [Authorize(Policy = PermissionPolicies.WarehousesManage)]
    public ActionResult<WarehouseDto> UpdateWarehouse(Guid warehouseId, UpdateWarehouseRequest request)
    {
        return Execute(() => Service.UpdateWarehouse(warehouseId, request));
    }

    [HttpDelete("{warehouseId:guid}")]
    [Authorize(Policy = PermissionPolicies.WarehousesManage)]
    public IActionResult DeleteWarehouse(Guid warehouseId)
    {
        return Execute(() => Service.DeleteWarehouse(warehouseId));
    }
}





