
namespace QuanLyDonHangNoiBo.Application.Features.Delivery.Commands.Upload_Pod;

public sealed class UploadProofOfDeliveryCommandHandler
{
    private readonly OmsApplicationService _service;

    public UploadProofOfDeliveryCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public ProofOfDeliveryDto Handle(UploadProofOfDeliveryCommand command)
    {
        return _service.UploadProofOfDelivery(command.ShipmentId, command.Request);
    }
}


