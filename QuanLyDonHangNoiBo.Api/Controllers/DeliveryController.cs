using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QuanLyDonHangNoiBo.Api.Hubs;
using QuanLyDonHangNoiBo.Api.Security;
using QuanLyDonHangNoiBo.Application.Features.Oms;

namespace QuanLyDonHangNoiBo.Api.Controllers;

[ApiController]
[Route("api")]
public sealed class DeliveryController : ApiControllerBase
{
    private readonly IHubContext<DeliveryHub> _deliveryHub;
    private readonly IHubContext<NotificationHub> _notificationHub;

    public DeliveryController(
        OmsApplicationService service,
        IHubContext<DeliveryHub> deliveryHub,
        IHubContext<NotificationHub> notificationHub)
        : base(service)
    {
        _deliveryHub = deliveryHub;
        _notificationHub = notificationHub;
    }

    [HttpGet("delivery/shipments")]
    [Authorize(Policy = PermissionPolicies.DeliveryRead)]
    public ActionResult<IReadOnlyList<ShipmentDto>> GetShipments([FromQuery] Guid? tenantId)
    {
        return Execute(() => Service.GetShipments(tenantId));
    }

    [HttpPost("delivery/shipments/{shipmentId:guid}/assign")]
    [Authorize(Policy = PermissionPolicies.DeliveryWrite)]
    public ActionResult<ShipmentDto> AssignShipment(Guid shipmentId, AssignShipmentRequest request)
    {
        return Execute(() => Service.AssignShipment(shipmentId, request));
    }

    [HttpPost("driver/shipments/{shipmentId:guid}/status")]
    [Authorize(Policy = PermissionPolicies.DeliveryWrite)]
    public async Task<ActionResult<ShipmentDto>> UpdateShipmentStatus(Guid shipmentId, UpdateShipmentStatusRequest request)
    {
        var shipment = Service.UpdateShipmentStatus(shipmentId, request);
        await PublishShipmentEvent(shipment, "ShipmentStatusChanged");
        return Ok(shipment);
    }

    [HttpGet("proof-of-deliveries")]
    [Authorize(Policy = PermissionPolicies.DeliveryRead)]
    public ActionResult<IReadOnlyList<ProofOfDeliveryDto>> GetProofOfDeliveries([FromQuery] Guid? tenantId, [FromQuery] Guid? shipmentId)
    {
        return Execute(() => Service.GetProofOfDeliveries(tenantId, shipmentId));
    }

    [HttpPost("delivery/shipments/{shipmentId:guid}/pod")]
    [HttpPost("driver/shipments/{shipmentId:guid}/pod")]
    [Authorize(Policy = PermissionPolicies.DeliveryWrite)]
    public async Task<ActionResult<ProofOfDeliveryDto>> UploadProofOfDelivery(Guid shipmentId, UploadProofOfDeliveryRequest request)
    {
        var proof = Service.UploadProofOfDelivery(shipmentId, request);
        await _deliveryHub.Clients.Group($"tenant:{proof.TenantId}").SendAsync("ProofOfDeliveryUploaded", proof);
        await _notificationHub.Clients.Group($"tenant:{proof.TenantId}").SendAsync("InAppNotificationReceived", new
        {
            title = "Proof of delivery uploaded",
            message = $"{proof.ShipmentCode} da co bang chung giao hang.",
            link = "/delivery"
        });
        return Ok(proof);
    }

    private Task PublishShipmentEvent(ShipmentDto shipment, string eventName)
    {
        return _deliveryHub.Clients.Group($"tenant:{shipment.TenantId}").SendAsync(eventName, shipment);
    }
}





