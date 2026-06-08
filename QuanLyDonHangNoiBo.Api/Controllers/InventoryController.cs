using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/inventory")]
public sealed class InventoryController : ApiControllerBase
{
    public InventoryController(OmsApplicationService service)
        : base(service)
    {
    }

    [HttpGet("stocks")]
    [Authorize(Policy = PermissionPolicies.InventoryRead)]
    public ActionResult<IReadOnlyList<InventoryStockDto>> GetInventoryStocks([FromQuery] Guid? tenantId, [FromQuery] Guid? warehouseId, [FromQuery] string? search)
    {
        return Execute(() => Service.GetInventoryStocks(tenantId, warehouseId, search));
    }

    [HttpGet("transactions")]
    [Authorize(Policy = PermissionPolicies.InventoryRead)]
    public ActionResult<IReadOnlyList<InventoryTransactionDto>> GetInventoryTransactions([FromQuery] Guid? tenantId, [FromQuery] Guid? warehouseId, [FromQuery] Guid? skuId)
    {
        return Execute(() => Service.GetInventoryTransactions(tenantId, warehouseId, skuId));
    }

    [HttpPost("stock-in")]
    [Authorize(Policy = PermissionPolicies.InventoryWrite)]
    public ActionResult<InventoryStockDto> StockIn(InventoryMutationRequest request)
    {
        return Execute(() => Service.StockIn(request));
    }

    [HttpPost("stock-out")]
    [Authorize(Policy = PermissionPolicies.InventoryWrite)]
    public ActionResult<InventoryStockDto> StockOut(InventoryMutationRequest request)
    {
        return Execute(() => Service.StockOutManual(request));
    }

    [HttpPost("adjustments")]
    [Authorize(Policy = PermissionPolicies.InventoryWrite)]
    public ActionResult<InventoryStockDto> AdjustInventory(InventoryMutationRequest request)
    {
        return Execute(() => Service.AdjustInventory(request));
    }
}





