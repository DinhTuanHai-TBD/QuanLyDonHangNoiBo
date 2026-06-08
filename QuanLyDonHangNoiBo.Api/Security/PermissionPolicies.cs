namespace QuanLyDonHangNoiBo.Api.Security;

public static class PermissionPolicies
{
    public const string DashboardRead = "perm:dashboard.read";
    public const string TenantsManage = "perm:tenants.manage";
    public const string UsersManage = "perm:users.manage";
    public const string CustomersManage = "perm:customers.manage";
    public const string ProductsManage = "perm:products.manage";
    public const string WarehousesManage = "perm:warehouses.manage";
    public const string OrdersRead = "perm:orders.read";
    public const string OrdersWrite = "perm:orders.write";
    public const string PickPackManage = "perm:pickpack.manage";
    public const string InventoryRead = "perm:inventory.read";
    public const string InventoryWrite = "perm:inventory.write";
    public const string DeliveryRead = "perm:delivery.read";
    public const string DeliveryWrite = "perm:delivery.write";
    public const string CodRead = "perm:cod.read";
    public const string CodReconcile = "perm:cod.reconcile";
    public const string ReturnsManage = "perm:returns.manage";
    public const string ReportsExport = "perm:reports.export";
    public const string ImportProducts = "perm:import.products";
    public const string AiAsk = "perm:ai.ask";

    public static IReadOnlyDictionary<string, string> All { get; } = new Dictionary<string, string>(StringComparer.Ordinal)
    {
        [DashboardRead] = "dashboard.read",
        [TenantsManage] = "tenants.manage",
        [UsersManage] = "users.manage",
        [CustomersManage] = "customers.manage",
        [ProductsManage] = "products.manage",
        [WarehousesManage] = "warehouses.manage",
        [OrdersRead] = "orders.read",
        [OrdersWrite] = "orders.write",
        [PickPackManage] = "pickpack.manage",
        [InventoryRead] = "inventory.read",
        [InventoryWrite] = "inventory.write",
        [DeliveryRead] = "delivery.read",
        [DeliveryWrite] = "delivery.write",
        [CodRead] = "cod.read",
        [CodReconcile] = "cod.reconcile",
        [ReturnsManage] = "returns.manage",
        [ReportsExport] = "reports.export",
        [ImportProducts] = "import.products",
        [AiAsk] = "ai.ask"
    };
}
