namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static IReadOnlyList<DemoWorkflowStepDto> BuildDemoWorkflow()
    {
        return
        [
            new(1, "Admin", "Ă„ÂĂ„Æ’ng nhĂ¡ÂºÂ­p vÄ‚Â  lĂ¡ÂºÂ¥y thÄ‚Â´ng tin quyĂ¡Â»Ân", "POST /api/auth/login"),
            new(2, "Sale", "TĂ¡ÂºÂ¡o khÄ‚Â¡ch hÄ‚Â ng hoĂ¡ÂºÂ·c dÄ‚Â¹ng khÄ‚Â¡ch hÄ‚Â ng mĂ¡ÂºÂ«u", "POST /api/customers"),
            new(3, "Sale", "TĂ¡ÂºÂ¡o Ă„â€˜Ă†Â¡n hÄ‚Â ng", "POST /api/orders"),
            new(4, "QuĂ¡ÂºÂ£n lÄ‚Â½", "XÄ‚Â¡c nhĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n vÄ‚Â  giĂ¡Â»Â¯ chĂ¡Â»â€” tĂ¡Â»â€œn kho", "POST /api/orders/{orderId}/confirm"),
            new(5, "Kho", "TĂ¡ÂºÂ¡o phiĂ¡ÂºÂ¿u pick vÄ‚Â  quÄ‚Â©t SKU/barcode", "POST /api/picklists, POST /api/picklists/{pickListId}/scan"),
            new(6, "Kho", "Ă„ÂÄ‚Â³ng gÄ‚Â³i vÄ‚Â  chuyĂ¡Â»Æ’n trĂ¡ÂºÂ¡ng thÄ‚Â¡i sĂ¡ÂºÂµn sÄ‚Â ng giao", "POST /api/packages"),
            new(7, "Ă„ÂiĂ¡Â»Âu phĂ¡Â»â€˜i", "GÄ‚Â¡n tÄ‚Â i xĂ¡ÂºÂ¿ cho vĂ¡ÂºÂ­n Ă„â€˜Ă†Â¡n", "POST /api/delivery/shipments/{shipmentId}/assign"),
            new(8, "TÄ‚Â i xĂ¡ÂºÂ¿", "CĂ¡ÂºÂ­p nhĂ¡ÂºÂ­t trĂ¡ÂºÂ¡ng thÄ‚Â¡i giao hÄ‚Â ng", "POST /api/driver/shipments/{shipmentId}/status"),
            new(9, "TÄ‚Â i xĂ¡ÂºÂ¿", "Upload bĂ¡ÂºÂ±ng chĂ¡Â»Â©ng giao hÄ‚Â ng POD", "POST /api/driver/shipments/{shipmentId}/pod"),
            new(10, "KĂ¡ÂºÂ¿ toÄ‚Â¡n", "Ă„ÂĂ¡Â»â€˜i soÄ‚Â¡t COD", "POST /api/cod/reconcile"),
            new(11, "CSKH/Kho", "TĂ¡ÂºÂ¡o vÄ‚Â  xĂ¡Â»Â­ lÄ‚Â½ hoÄ‚Â n hÄ‚Â ng nĂ¡ÂºÂ¿u phÄ‚Â¡t sinh", "POST /api/returns, POST /api/returns/{returnId}/status"),
            new(12, "QuĂ¡ÂºÂ£n lÄ‚Â½", "Xem dashboard vÄ‚Â  export bÄ‚Â¡o cÄ‚Â¡o", "GET /api/dashboard, POST /api/exports")
        ];
    }
}

