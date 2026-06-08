namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private void ValidateTenantInput(string code, string name, int userLimit, int orderLimit, int warehouseLimit, Guid? currentTenantId)
    {
        if (string.IsNullOrWhiteSpace(code) || code.Trim().Length < 2)
        {
            throw new InvalidOperationException("Ma tenant phai co it nhat 2 ky tu.");
        }

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new InvalidOperationException("Ten tenant la bat buoc.");
        }

        if (userLimit <= 0 || orderLimit <= 0 || warehouseLimit <= 0)
        {
            throw new InvalidOperationException("Gioi han user/order/kho phai lon hon 0.");
        }

        var normalizedCode = code.Trim().ToLowerInvariant();
        if (_repository.Tenants.Any(item => item.Id != currentTenantId && item.Code.Equals(normalizedCode, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException("Ma tenant da ton tai.");
        }
    }
}

