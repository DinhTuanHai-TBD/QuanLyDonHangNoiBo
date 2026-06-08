namespace QuanLyDonHangNoiBo.Application.Features.Oms;

public sealed partial class OmsApplicationService
{
    private static IReadOnlyList<string> BuildSmokeTestEndpoints()
    {
        return
        [
            "GET /api/demo/readiness",
            "POST /api/auth/login",
            "GET /api/metadata",
            "GET /api/users",
            "GET /api/orders",
            "GET /api/inventory/stocks",
            "GET /api/delivery/shipments",
            "GET /api/cod/collections",
            "GET /api/dashboard",
            "GET /api/permissions"
        ];
    }
}

