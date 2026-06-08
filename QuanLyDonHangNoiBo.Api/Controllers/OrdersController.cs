using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Hubs;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api/orders")]
public sealed class OrdersController : ApiControllerBase
{
    private readonly IHubContext<OrderHub> _orderHub;
    private readonly IHubContext<DashboardHub> _dashboardHub;

    public OrdersController(
        OmsApplicationService service,
        IHubContext<OrderHub> orderHub,
        IHubContext<DashboardHub> dashboardHub)
        : base(service)
    {
        _orderHub = orderHub;
        _dashboardHub = dashboardHub;
    }

    [HttpGet]
    [Authorize(Policy = PermissionPolicies.OrdersRead)]
    public ActionResult<PagedResult<OrderSummaryDto>> GetOrders([FromQuery] OrderQuery query)
    {
        return Execute(() => Service.GetOrders(query));
    }

    [HttpGet("{orderId:guid}")]
    [Authorize(Policy = PermissionPolicies.OrdersRead)]
    public ActionResult<OrderDetailDto> GetOrder(Guid orderId)
    {
        return Execute(() => Service.GetOrder(orderId));
    }

    [HttpPost]
    [Authorize(Policy = PermissionPolicies.OrdersWrite)]
    public async Task<ActionResult<OrderDetailDto>> CreateOrder(CreateOrderRequest request)
    {
        var order = Service.CreateOrder(request);
        await PublishOrderEvent(order, "OrderCreated");
        return Ok(order);
    }

    [HttpPost("{orderId:guid}/confirm")]
    [Authorize(Policy = PermissionPolicies.OrdersWrite)]
    public async Task<ActionResult<OrderDetailDto>> ConfirmOrder(Guid orderId, UserActionRequest? request)
    {
        var order = Service.ConfirmOrder(orderId, request?.UserId);
        await PublishOrderEvent(order, "OrderStatusChanged");
        return Ok(order);
    }

    [HttpPost("{orderId:guid}/cancel")]
    [Authorize(Policy = PermissionPolicies.OrdersWrite)]
    public async Task<ActionResult<OrderDetailDto>> CancelOrder(Guid orderId, UserActionRequest request)
    {
        var order = Service.CancelOrder(orderId, request.Note, request.UserId);
        await PublishOrderEvent(order, "OrderStatusChanged");
        return Ok(order);
    }

    [HttpPost("{orderId:guid}/status")]
    [Authorize(Policy = PermissionPolicies.OrdersWrite)]
    public async Task<ActionResult<OrderDetailDto>> UpdateOrderStatus(Guid orderId, UpdateOrderStatusRequest request)
    {
        var order = Service.UpdateOrderStatus(orderId, request);
        await PublishOrderEvent(order, "OrderStatusChanged");
        return Ok(order);
    }

    private async Task PublishOrderEvent(OrderDetailDto order, string eventName)
    {
        await _orderHub.Clients.Group($"tenant:{order.TenantId}").SendAsync(eventName, order);
        await _orderHub.Clients.Group($"order:{order.TenantId}:{order.Id}").SendAsync(eventName, order);
        await _dashboardHub.Clients.Group($"tenant:{order.TenantId}").SendAsync("DashboardMetricsUpdated", new
        {
            orderId = order.Id,
            orderCode = order.OrderCode,
            status = order.Status,
            changedAt = DateTimeOffset.UtcNow
        });
    }
}





