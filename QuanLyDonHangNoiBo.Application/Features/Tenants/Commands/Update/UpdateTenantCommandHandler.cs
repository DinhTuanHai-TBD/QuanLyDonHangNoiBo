
namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Commands.Update;

public sealed class UpdateTenantCommandHandler
{
    private readonly OmsApplicationService _service;

    public UpdateTenantCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public TenantDto Handle(UpdateTenantCommand command)
    {
        return _service.UpdateTenant(command.TenantId, command.Request);
    }
}


