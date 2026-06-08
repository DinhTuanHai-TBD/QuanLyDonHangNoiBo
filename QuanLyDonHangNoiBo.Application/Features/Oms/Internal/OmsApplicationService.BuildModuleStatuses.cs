namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static IReadOnlyList<DemoModuleStatusDto> BuildModuleStatuses()
    {
        return
        [
            new("QuĂ¡ÂºÂ£n lÄ‚Â½ tenant", "Ă„ÂĂ¡Â»Â§ demo API", "GET/POST/PUT/DELETE /api/tenants", "DÄ‚Â¹ng cho mÄ‚Â´ hÄ‚Â¬nh nhiĂ¡Â»Âu cÄ‚Â´ng ty/chi nhÄ‚Â¡nh."),
            new("QuĂ¡ÂºÂ£n lÄ‚Â½ ngĂ†Â°Ă¡Â»Âi dÄ‚Â¹ng", "Ă„ÂĂ¡Â»Â§ CRUD", "GET/POST/PUT/DELETE /api/users", "CÄ‚Â³ role, trĂ¡ÂºÂ¡ng thÄ‚Â¡i active/deactive, gÄ‚Â¡n kho."),
            new("PhÄ‚Â¢n quyĂ¡Â»Ân", "Ă„ÂĂ¡Â»Â§ demo API", "GET /api/permissions, GET /api/roles/permissions", "CÄ‚Â³ danh mĂ¡Â»Â¥c quyĂ¡Â»Ân theo module vÄ‚Â  role."),
            new("KhÄ‚Â¡ch hÄ‚Â ng", "Ă„ÂĂ¡Â»Â§ CRUD", "GET/POST/PUT/DELETE /api/customers", "TĂ¡ÂºÂ¡o khÄ‚Â¡ch trĂ†Â°Ă¡Â»â€ºc khi tĂ¡ÂºÂ¡o Ă„â€˜Ă†Â¡n."),
            new("SĂ¡ÂºÂ£n phĂ¡ÂºÂ©m/SKU", "Ă„ÂĂ¡Â»Â§ CRUD", "GET/POST/PUT/DELETE /api/products", "CÄ‚Â³ SKU, barcode, giÄ‚Â¡ vÄ‚Â  ngĂ†Â°Ă¡Â»Â¡ng tĂ¡Â»â€œn thĂ¡ÂºÂ¥p."),
            new("Kho", "Ă„ÂĂ¡Â»Â§ CRUD", "GET/POST/PUT/DELETE /api/warehouses", "DÄ‚Â¹ng cho Ă„â€˜iĂ¡Â»Âu phĂ¡Â»â€˜i tĂ¡Â»â€œn kho vÄ‚Â  Ă„â€˜Ă†Â¡n hÄ‚Â ng."),
            new("TĂ¡Â»â€œn kho", "Ă„ÂĂ¡Â»Â§ demo API", "GET /api/inventory/stocks, POST stock-in/stock-out/adjustments", "CÄ‚Â³ giĂ¡Â»Â¯ chĂ¡Â»â€” tĂ¡Â»â€œn khi xÄ‚Â¡c nhĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n."),
            new("Ă„ÂĂ†Â¡n hÄ‚Â ng", "Ă„ÂĂ¡Â»Â§ luĂ¡Â»â€œng chÄ‚Â­nh", "GET/POST /api/orders, POST confirm/cancel/status", "TĂ¡ÂºÂ¡o Ă„â€˜Ă†Â¡n, xÄ‚Â¡c nhĂ¡ÂºÂ­n, hĂ¡Â»Â§y, Ă„â€˜Ă¡Â»â€¢i trĂ¡ÂºÂ¡ng thÄ‚Â¡i."),
            new("Pick/Pack", "Ă„ÂĂ¡Â»Â§ demo API", "GET/POST /api/picklists, POST /scan, GET/POST /api/packages", "Demo bĂ¡Â»â„¢ phĂ¡ÂºÂ­n kho nhĂ¡ÂºÂ·t hÄ‚Â ng vÄ‚Â  Ă„â€˜Ä‚Â³ng gÄ‚Â³i."),
            new("Giao hÄ‚Â ng", "Ă„ÂĂ¡Â»Â§ demo API", "GET /api/delivery/shipments, POST assign/status", "Demo Ă„â€˜iĂ¡Â»Âu phĂ¡Â»â€˜i vÄ‚Â  tÄ‚Â i xĂ¡ÂºÂ¿ cĂ¡ÂºÂ­p nhĂ¡ÂºÂ­t vĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n."),
            new("POD", "Ă„ÂĂ¡Â»Â§ demo API", "GET /api/proof-of-deliveries, POST /pod", "LĂ†Â°u Ă¡ÂºÂ£nh/chĂ¡Â»Â¯ kÄ‚Â½/tĂ¡Â»Âa Ă„â€˜Ă¡Â»â„¢ giao hÄ‚Â ng dĂ¡ÂºÂ¡ng URL demo."),
            new("COD/KĂ¡ÂºÂ¿ toÄ‚Â¡n", "Ă„ÂĂ¡Â»Â§ demo API", "GET /api/cod/collections, POST /api/cod/reconcile", "Theo dÄ‚Âµi thu hĂ¡Â»â„¢ vÄ‚Â  Ă„â€˜Ă¡Â»â€˜i soÄ‚Â¡t."),
            new("HoÄ‚Â n hÄ‚Â ng", "Ă„ÂĂ¡Â»Â§ demo API", "GET/POST /api/returns, POST /status", "CÄ‚Â³ duyĂ¡Â»â€¡t, nhĂ¡ÂºÂ­n hÄ‚Â ng hoÄ‚Â n vÄ‚Â  nhĂ¡ÂºÂ­p lĂ¡ÂºÂ¡i kho."),
            new("Dashboard/BÄ‚Â¡o cÄ‚Â¡o", "Ă„ÂĂ¡Â»Â§ demo API", "GET /api/dashboard, POST /api/exports", "CÄ‚Â³ KPI, pipeline, export job giĂ¡ÂºÂ£ lĂ¡ÂºÂ­p."),
            new("ThÄ‚Â´ng bÄ‚Â¡o realtime", "Ă„ÂĂ¡Â»Â§ demo hub", "/hubs/orders, /hubs/delivery, /hubs/notifications, /hubs/dashboard", "SignalR phÄ‚Â¡t sĂ¡Â»Â± kiĂ¡Â»â€¡n khi thao tÄ‚Â¡c chÄ‚Â­nh."),
            new("AI hĂ¡Â»â€” trĂ¡Â»Â£", "Mock demo", "POST /api/ai/chat", "TrĂ¡ÂºÂ£ lĂ¡Â»Âi theo dĂ¡Â»Â¯ liĂ¡Â»â€¡u vĂ¡ÂºÂ­n hÄ‚Â nh mĂ¡ÂºÂ«u, chĂ†Â°a gĂ¡Â»Âi AI thĂ¡ÂºÂ­t."),
            new("Database schema", "Ă„ÂÄ‚Â£ cÄ‚Â³ migration", "AppDbContext + Persistence/Migrations", "Schema SQL Server Ă„â€˜Ä‚Â£ cÄ‚Â³, runtime demo Ă„â€˜ang dÄ‚Â¹ng in-memory.")
        ];
    }
}

