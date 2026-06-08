
namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static IReadOnlyList<string> GetPermissions(UserRole role)
    {
        var all = new[]
        {
            "dashboard.read",
            "tenants.manage",
            "users.manage",
            "customers.manage",
            "products.manage",
            "warehouses.manage",
            "orders.read",
            "orders.write",
            "pickpack.manage",
            "inventory.read",
            "inventory.write",
            "delivery.read",
            "delivery.write",
            "cod.read",
            "cod.reconcile",
            "returns.manage",
            "reports.export",
            "import.products",
            "ai.ask"
        };

        return role switch
        {
            UserRole.SuperAdmin => all,
            UserRole.TenantAdmin => all.Where(item => item != "tenants.manage").ToArray(),
            UserRole.Sales => ["dashboard.read", "customers.manage", "orders.read", "orders.write", "ai.ask"],
            UserRole.Warehouse => ["orders.read", "pickpack.manage", "inventory.read", "inventory.write", "delivery.read"],
            UserRole.InventoryManager => ["dashboard.read", "products.manage", "warehouses.manage", "inventory.read", "inventory.write", "import.products", "ai.ask"],
            UserRole.Dispatcher => ["dashboard.read", "orders.read", "delivery.read", "delivery.write", "ai.ask"],
            UserRole.Driver => ["delivery.read", "delivery.write"],
            UserRole.Accountant => ["dashboard.read", "cod.read", "cod.reconcile", "reports.export", "ai.ask"],
            UserRole.Manager => ["dashboard.read", "customers.manage", "products.manage", "orders.read", "orders.write", "inventory.read", "delivery.read", "cod.read", "returns.manage", "reports.export", "ai.ask"],
            _ => []
        };
    }
}

