
namespace QuanLyDonHangNoiBo.Application.Features.Tenants.Commands.Create;

public sealed class CreateTenantCommandHandler
{
    private readonly OmsApplicationService _service;

    public CreateTenantCommandHandler(OmsApplicationService service)
    {
        _service = service;
    }

    public TenantDto Handle(CreateTenantCommand command)
    {
        return _service.CreateTenant(command.Request);
    }
}


