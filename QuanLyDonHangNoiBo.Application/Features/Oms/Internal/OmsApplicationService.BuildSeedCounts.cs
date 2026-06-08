namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private IReadOnlyList<DemoSeedCountDto> BuildSeedCounts(Guid tenantId)
    {
        return
        [
            new("Tenant", _repository.Tenants.Count(item => item.Id == tenantId), "CÄ‚Â´ng ty demo dÄ‚Â¹ng mÄ‚Â£ tenant 'demo'."),
            new("NgĂ†Â°Ă¡Â»Âi dÄ‚Â¹ng/BĂ¡Â»â„¢ phĂ¡ÂºÂ­n", _repository.Users.Count(item => item.TenantId == tenantId), "CÄ‚Â³ admin, quĂ¡ÂºÂ£n lÄ‚Â½, sale, kho, Ă„â€˜iĂ¡Â»Âu phĂ¡Â»â€˜i, tÄ‚Â i xĂ¡ÂºÂ¿, kĂ¡ÂºÂ¿ toÄ‚Â¡n."),
            new("KhÄ‚Â¡ch hÄ‚Â ng", _repository.Customers.Count(item => item.TenantId == tenantId), "DĂ¡Â»Â¯ liĂ¡Â»â€¡u mĂ¡ÂºÂ«u Ă„â€˜Ă¡Â»Â§ Ă„â€˜Ă¡Â»Æ’ tĂ¡ÂºÂ¡o vÄ‚Â  tra cĂ¡Â»Â©u Ă„â€˜Ă†Â¡n hÄ‚Â ng."),
            new("SĂ¡ÂºÂ£n phĂ¡ÂºÂ©m", _repository.Products.Count(item => item.TenantId == tenantId), "MĂ¡Â»â€”i sĂ¡ÂºÂ£n phĂ¡ÂºÂ©m cÄ‚Â³ thĂ¡Â»Æ’ cÄ‚Â³ nhiĂ¡Â»Âu SKU."),
            new("SKU", _repository.Skus.Count(item => item.TenantId == tenantId), "CÄ‚Â³ barcode Ă„â€˜Ă¡Â»Æ’ demo quÄ‚Â©t pick hÄ‚Â ng."),
            new("Kho", _repository.Warehouses.Count(item => item.TenantId == tenantId), "CÄ‚Â³ kho HÄ‚Â  NĂ¡Â»â„¢i, TP.HCM, Ă„ÂÄ‚Â  NĂ¡ÂºÂµng."),
            new("TĂ¡Â»â€œn kho", _repository.InventoryStocks.Count(item => item.TenantId == tenantId), "Theo dÄ‚Âµi tĂ¡Â»â€œn thĂ¡Â»Â±c, tĂ¡Â»â€œn giĂ¡Â»Â¯ chĂ¡Â»â€” vÄ‚Â  tĂ¡Â»â€œn khĂ¡ÂºÂ£ dĂ¡Â»Â¥ng."),
            new("Giao dĂ¡Â»â€¹ch kho", _repository.InventoryTransactions.Count(item => item.TenantId == tenantId), "CÄ‚Â³ nhĂ¡ÂºÂ­p/xuĂ¡ÂºÂ¥t/giĂ¡Â»Â¯ chĂ¡Â»â€”/xĂ¡ÂºÂ£ giĂ¡Â»Â¯ chĂ¡Â»â€”/hoÄ‚Â n kho."),
            new("Ă„ÂĂ†Â¡n hÄ‚Â ng", _repository.Orders.Count(item => item.TenantId == tenantId), "CÄ‚Â³ nhiĂ¡Â»Âu trĂ¡ÂºÂ¡ng thÄ‚Â¡i Ă„â€˜Ă¡Â»Æ’ lĂ¡Â»Âc vÄ‚Â  Ă„â€˜Ă¡Â»â€¢i trĂ¡ÂºÂ¡ng thÄ‚Â¡i."),
            new("LĂ¡Â»â€¹ch sĂ¡Â»Â­ trĂ¡ÂºÂ¡ng thÄ‚Â¡i Ă„â€˜Ă†Â¡n", _repository.OrderStatusHistories.Count(item => item.TenantId == tenantId), "Theo dÄ‚Âµi audit luĂ¡Â»â€œng Ă„â€˜Ă†Â¡n hÄ‚Â ng."),
            new("Pick list", _repository.PickLists.Count(item => item.TenantId == tenantId), "TĂ¡ÂºÂ¡o mĂ¡Â»â€ºi bĂ¡ÂºÂ±ng API khi test Postman."),
            new("KiĂ¡Â»â€¡n hÄ‚Â ng", _repository.Packages.Count(item => item.TenantId == tenantId), "TĂ¡ÂºÂ¡o mĂ¡Â»â€ºi sau khi hoÄ‚Â n tĂ¡ÂºÂ¥t pick list."),
            new("VĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n", _repository.Shipments.Count(item => item.TenantId == tenantId), "CÄ‚Â³ vĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n mĂ¡ÂºÂ«u vÄ‚Â  tĂ¡Â»Â± tĂ¡ÂºÂ¡o khi Ă„â€˜Ă†Â¡n sĂ¡ÂºÂµn sÄ‚Â ng giao."),
            new("POD", _repository.ProofOfDeliveries.Count(item => item.TenantId == tenantId), "Upload bĂ¡ÂºÂ±ng API Ă„â€˜Ă¡Â»Æ’ hoÄ‚Â n tĂ¡ÂºÂ¥t giao hÄ‚Â ng."),
            new("COD", _repository.CodCollections.Count(item => item.TenantId == tenantId), "CÄ‚Â³ thu hĂ¡Â»â„¢ vÄ‚Â  Ă„â€˜Ă¡Â»â€˜i soÄ‚Â¡t COD."),
            new("HoÄ‚Â n hÄ‚Â ng", _repository.Returns.Count(item => item.TenantId == tenantId), "TĂ¡ÂºÂ¡o mĂ¡Â»â€ºi bĂ¡ÂºÂ±ng API khi test Postman."),
            new("ThÄ‚Â´ng bÄ‚Â¡o", _repository.Notifications.Count(item => item.TenantId == tenantId), "HiĂ¡Â»Æ’n thĂ¡Â»â€¹ cĂ¡ÂºÂ£nh bÄ‚Â¡o vĂ¡ÂºÂ­n hÄ‚Â nh."),
            new("Audit log", _repository.AuditLogs.Count(item => item.TenantId == tenantId), "PhÄ‚Â¡t sinh khi thao tÄ‚Â¡c CRUD/trĂ¡ÂºÂ¡ng thÄ‚Â¡i."),
            new("AI insight", _repository.AiInsights.Count(item => item.TenantId == tenantId), "DĂ¡Â»Â¯ liĂ¡Â»â€¡u demo cho trĂ¡Â»Â£ lÄ‚Â½ AI vĂ¡ÂºÂ­n hÄ‚Â nh."),
            new("Export job", _repository.ExportJobs.Count(item => item.TenantId == tenantId), "TĂ¡ÂºÂ¡o mĂ¡Â»â€ºi bĂ¡ÂºÂ±ng API export bÄ‚Â¡o cÄ‚Â¡o.")
        ];
    }
}

