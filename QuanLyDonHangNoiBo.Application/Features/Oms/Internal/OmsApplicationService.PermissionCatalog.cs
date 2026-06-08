namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static readonly IReadOnlyList<PermissionDto> PermissionCatalog =
        [
            new("dashboard.read", "Dashboard", "Read", "Xem dashboard vĂ¡ÂºÂ­n hÄ‚Â nh"),
        new("tenants.manage", "Tenants", "Manage", "QuĂ¡ÂºÂ£n lÄ‚Â½ tenant/cÄ‚Â´ng ty dÄ‚Â¹ng hĂ¡Â»â€¡ thĂ¡Â»â€˜ng"),
        new("users.manage", "Users", "Manage", "QuĂ¡ÂºÂ£n lÄ‚Â½ ngĂ†Â°Ă¡Â»Âi dÄ‚Â¹ng, role vÄ‚Â  trĂ¡ÂºÂ¡ng thÄ‚Â¡i hoĂ¡ÂºÂ¡t Ă„â€˜Ă¡Â»â„¢ng"),
        new("customers.manage", "Customers", "Manage", "QuĂ¡ÂºÂ£n lÄ‚Â½ khÄ‚Â¡ch hÄ‚Â ng"),
        new("products.manage", "Products", "Manage", "QuĂ¡ÂºÂ£n lÄ‚Â½ sĂ¡ÂºÂ£n phĂ¡ÂºÂ©m vÄ‚Â  SKU"),
        new("warehouses.manage", "Warehouses", "Manage", "QuĂ¡ÂºÂ£n lÄ‚Â½ kho"),
        new("orders.read", "Orders", "Read", "Xem Ă„â€˜Ă†Â¡n hÄ‚Â ng"),
        new("orders.write", "Orders", "Write", "TĂ¡ÂºÂ¡o vÄ‚Â  cĂ¡ÂºÂ­p nhĂ¡ÂºÂ­t Ă„â€˜Ă†Â¡n hÄ‚Â ng"),
        new("pickpack.manage", "Warehouse", "Manage", "TĂ¡ÂºÂ¡o pick list, quÄ‚Â©t hÄ‚Â ng vÄ‚Â  Ă„â€˜Ä‚Â³ng gÄ‚Â³i"),
        new("inventory.read", "Inventory", "Read", "Xem tĂ¡Â»â€œn kho"),
        new("inventory.write", "Inventory", "Write", "NhĂ¡ÂºÂ­p kho, xuĂ¡ÂºÂ¥t kho vÄ‚Â  Ă„â€˜iĂ¡Â»Âu chĂ¡Â»â€°nh tĂ¡Â»â€œn"),
        new("delivery.read", "Delivery", "Read", "Xem vĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n"),
        new("delivery.write", "Delivery", "Write", "GÄ‚Â¡n tÄ‚Â i xĂ¡ÂºÂ¿ vÄ‚Â  cĂ¡ÂºÂ­p nhĂ¡ÂºÂ­t trĂ¡ÂºÂ¡ng thÄ‚Â¡i giao hÄ‚Â ng"),
        new("cod.read", "Finance", "Read", "Xem khoĂ¡ÂºÂ£n COD"),
        new("cod.reconcile", "Finance", "Write", "Ă„ÂĂ¡Â»â€˜i soÄ‚Â¡t COD"),
        new("returns.manage", "Returns", "Manage", "TĂ¡ÂºÂ¡o vÄ‚Â  xĂ¡Â»Â­ lÄ‚Â½ hoÄ‚Â n hÄ‚Â ng"),
        new("reports.export", "Reports", "Export", "TĂ¡ÂºÂ¡o job export bÄ‚Â¡o cÄ‚Â¡o demo"),
        new("import.products", "Import", "Write", "Import danh sÄ‚Â¡ch sĂ¡ÂºÂ£n phĂ¡ÂºÂ©m demo"),
        new("ai.ask", "AI", "Use", "HĂ¡Â»Âi trĂ¡Â»Â£ lÄ‚Â½ AI vĂ¡ÂºÂ­n hÄ‚Â nh")
        ];
}

