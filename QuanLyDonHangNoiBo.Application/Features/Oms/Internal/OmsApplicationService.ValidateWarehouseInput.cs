namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void ValidateWarehouseInput(Guid tenantId, string code, string name, Guid? currentWarehouseId)
    {
        if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Ma va ten kho la bat buoc.");
        }

        var normalizedCode = code.Trim().ToUpperInvariant();
        if (_repository.Warehouses.Any(item => item.TenantId == tenantId && item.Id != currentWarehouseId && item.Code.Equals(normalizedCode, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Ma kho da ton tai.");
        }
    }
}

