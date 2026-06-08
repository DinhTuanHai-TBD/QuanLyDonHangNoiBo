using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    private void Seed()
    {
        // DÄ‚Â¡Ă‚Â»Ă‚Â¯ liÄ‚Â¡Ă‚Â»Ă¢â‚¬Â¡u mÄ‚Â¡Ă‚ÂºĂ‚Â«u bĂ„â€Ă‚Â¡m theo cĂ„â€Ă‚Â¡c bÄ‚Â¡Ă‚Â»Ă¢â€Â¢ phÄ‚Â¡Ă‚ÂºĂ‚Â­n chĂ„â€Ă‚Â­nh cÄ‚Â¡Ă‚Â»Ă‚Â§a OMS: sale, kho, Ä‚â€Ă¢â‚¬ËœiÄ‚Â¡Ă‚Â»Ă‚Âu phÄ‚Â¡Ă‚Â»Ă¢â‚¬Ëœi, tĂ„â€Ă‚Â i xÄ‚Â¡Ă‚ÂºĂ‚Â¿, kÄ‚Â¡Ă‚ÂºĂ‚Â¿ toĂ„â€Ă‚Â¡n vĂ„â€Ă‚Â  quÄ‚Â¡Ă‚ÂºĂ‚Â£n lĂ„â€Ă‚Â½.
        var tenant = new Tenant
        {
            Code = "demo",
            Name = "Cong ty Demo OMS",
            Plan = "Business",
            Status = TenantStatus.Active,
            UserLimit = 80,
            OrderLimit = 25000,
            WarehouseLimit = 8,
            DefaultLocale = "vi",
            CreatedAt = DateTimeOffset.UtcNow.AddMonths(-5)
        };
        _tenants.Add(tenant);

        var hn = new Warehouse { TenantId = tenant.Id, Code = "HN-01", Name = "Kho Ha Noi", Province = "Ha Noi", Address = "Cau Giay, Ha Noi" };
        var hcm = new Warehouse { TenantId = tenant.Id, Code = "HCM-01", Name = "Kho TP.HCM", Province = "TP.HCM", Address = "Quan 7, TP.HCM" };
        var dn = new Warehouse { TenantId = tenant.Id, Code = "DN-01", Name = "Kho Da Nang", Province = "Da Nang", Address = "Hai Chau, Da Nang" };
        _warehouses.AddRange([hn, hcm, dn]);

        var demoPasswordHash = QuanLyDonHangNoiBo.Application.Common.Security.PasswordHasher.HashPassword("Demo@123");
        _users.AddRange([
            new AppUser { TenantId = tenant.Id, FullName = "Nguyen Minh Anh", Email = "admin@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.TenantAdmin },
            new AppUser { TenantId = tenant.Id, FullName = "Tran Quoc Bao", Email = "manager@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Manager },
            new AppUser { TenantId = tenant.Id, FullName = "Le Thu Ha", Email = "sales@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Sales },
            new AppUser { TenantId = tenant.Id, FullName = "Pham Van Khoi", Email = "warehouse@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Warehouse, WarehouseId = hn.Id },
            new AppUser { TenantId = tenant.Id, FullName = "Do Gia Linh", Email = "inventory@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.InventoryManager },
            new AppUser { TenantId = tenant.Id, FullName = "Hoang Nam", Email = "dispatcher@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Dispatcher },
            new AppUser { TenantId = tenant.Id, FullName = "Bui Duc Tai", Email = "driver1@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Driver },
            new AppUser { TenantId = tenant.Id, FullName = "Vo Thanh Son", Email = "driver2@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Driver },
            new AppUser { TenantId = tenant.Id, FullName = "Nguyen Phuong Chi", Email = "accountant@demo.vn", PasswordHash = demoPasswordHash, Role = UserRole.Accountant }
        ]);

        _customers.AddRange([
            new Customer { TenantId = tenant.Id, Code = "CUS-0001", Name = "Cua hang An Phat", Phone = "0901000001", Email = "anphat@example.vn", Address = "12 Lang Ha, Ha Noi", Province = "Ha Noi", Segment = "Wholesale", Note = "Khach uu tien COD" },
            new Customer { TenantId = tenant.Id, Code = "CUS-0002", Name = "Nguyen Van An", Phone = "0901000002", Email = "an.nguyen@example.vn", Address = "45 Le Loi, TP.HCM", Province = "TP.HCM", Segment = "Retail" },
            new Customer { TenantId = tenant.Id, Code = "CUS-0003", Name = "Shop Miu Miu", Phone = "0901000003", Email = "shopmiumiu@example.vn", Address = "88 Nguyen Van Linh, Da Nang", Province = "Da Nang", Segment = "Marketplace" },
            new Customer { TenantId = tenant.Id, Code = "CUS-0004", Name = "Cong ty Bao Minh", Phone = "0901000004", Email = "baominh@example.vn", Address = "21 Nguyen Trai, Ha Noi", Province = "Ha Noi", Segment = "B2B" },
            new Customer { TenantId = tenant.Id, Code = "CUS-0005", Name = "Tran Thi Bich", Phone = "0901000005", Email = "bich.tran@example.vn", Address = "5 Phan Xich Long, TP.HCM", Province = "TP.HCM", Segment = "Retail" }
        ]);

        var coffee = AddSeedProduct(tenant.Id, "PRD-COF", "Ca phe rang xay", "FMCG", [
            ("SKU-COF-250", "8930001002501", "Goi 250g", 68000m, 25),
            ("SKU-COF-500", "8930001005001", "Goi 500g", 125000m, 18)
        ]);
        var tea = AddSeedProduct(tenant.Id, "PRD-TEA", "Tra thao moc", "FMCG", [
            ("SKU-TEA-BOX", "8930002001001", "Hop 20 tui", 89000m, 12)
        ]);
        var bottle = AddSeedProduct(tenant.Id, "PRD-BOT", "Binh giu nhiet", "Accessories", [
            ("SKU-BOT-500", "8930003005001", "500ml bac", 199000m, 8),
            ("SKU-BOT-750", "8930003007501", "750ml den", 249000m, 8)
        ]);
        var snack = AddSeedProduct(tenant.Id, "PRD-SNK", "Hat dinh duong", "FMCG", [
            ("SKU-SNK-CASHEW", "8930004001001", "Hat dieu 300g", 115000m, 15)
        ]);

        foreach (var sku in _skus)
        {
            _inventoryStocks.Add(new InventoryStock { TenantId = tenant.Id, WarehouseId = hn.Id, SkuId = sku.Id, OnHand = StockFor(sku.SkuCode, hn.Code), Reserved = 0 });
            _inventoryStocks.Add(new InventoryStock { TenantId = tenant.Id, WarehouseId = hcm.Id, SkuId = sku.Id, OnHand = StockFor(sku.SkuCode, hcm.Code), Reserved = 0 });
            _inventoryStocks.Add(new InventoryStock { TenantId = tenant.Id, WarehouseId = dn.Id, SkuId = sku.Id, OnHand = StockFor(sku.SkuCode, dn.Code), Reserved = 0 });
        }

        var driver1 = _users.First(item => item.Email == "driver1@demo.vn");
        var driver2 = _users.First(item => item.Email == "driver2@demo.vn");

        AddSeedOrder(tenant.Id, "ORD-260511-0001", _customers[0], hn, OrderStatus.Delivered, PaymentMethod.Cod, DateTimeOffset.UtcNow.AddHours(-7), [
            (coffee.Skus[1], 4),
            (snack.Skus[0], 2)
        ], driver1, ShipmentStatus.Delivered, CodStatus.Collected);

        AddSeedOrder(tenant.Id, "ORD-260511-0002", _customers[1], hcm, OrderStatus.InTransit, PaymentMethod.Cod, DateTimeOffset.UtcNow.AddHours(-5), [
            (bottle.Skus[0], 1),
            (tea.Skus[0], 3)
        ], driver2, ShipmentStatus.InTransit, null);

        AddSeedOrder(tenant.Id, "ORD-260511-0003", _customers[2], dn, OrderStatus.Picking, PaymentMethod.BankTransfer, DateTimeOffset.UtcNow.AddHours(-3), [
            (coffee.Skus[0], 5)
        ], null, null, null);

        AddSeedOrder(tenant.Id, "ORD-260510-0004", _customers[3], hn, OrderStatus.Failed, PaymentMethod.Cod, DateTimeOffset.UtcNow.AddDays(-1).AddHours(-2), [
            (bottle.Skus[1], 2)
        ], driver1, ShipmentStatus.Failed, null);

        AddSeedOrder(tenant.Id, "ORD-260510-0005", _customers[4], hcm, OrderStatus.Packed, PaymentMethod.Cod, DateTimeOffset.UtcNow.AddDays(-1), [
            (tea.Skus[0], 2),
            (snack.Skus[0], 1)
        ], null, null, null);

        AddSeedOrder(tenant.Id, "ORD-260509-0006", _customers[0], hn, OrderStatus.Confirmed, PaymentMethod.Cod, DateTimeOffset.UtcNow.AddDays(-2), [
            (coffee.Skus[0], 10)
        ], null, null, null);

        _notifications.AddRange([
            new NotificationItem { TenantId = tenant.Id, Title = "COD can doi soat", Message = "3 phieu COD da thu tien nhung chua doi soat.", Severity = NotificationSeverity.Warning, Link = "/finance", CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-20) },
            new NotificationItem { TenantId = tenant.Id, Title = "SKU sap het hang", Message = "SKU-BOT-750 tai kho HN-01 duoi nguong canh bao.", Severity = NotificationSeverity.Critical, Link = "/inventory", CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-35) },
            new NotificationItem { TenantId = tenant.Id, Title = "Don giao that bai", Message = "ORD-260510-0004 can len lich giao lai.", Severity = NotificationSeverity.Warning, Link = "/delivery", CreatedAt = DateTimeOffset.UtcNow.AddHours(-1) }
        ]);

        _aiInsights.AddRange([
            new AiInsight { TenantId = tenant.Id, Title = "COD chua doi soat tang", Summary = "Gia tri COD cho doi soat cao hon 18% so voi trung binh 7 ngay.", Severity = NotificationSeverity.Warning, Link = "/finance", CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-15) },
            new AiInsight { TenantId = tenant.Id, Title = "Kho HN sap thieu SKU binh 750ml", Summary = "Toc do ban 3 ngay gan nhat co the lam het hang trong 2 ngay.", Severity = NotificationSeverity.Critical, Link = "/inventory", CreatedAt = DateTimeOffset.UtcNow.AddMinutes(-40) },
            new AiInsight { TenantId = tenant.Id, Title = "Tuyen TP.HCM can toi uu", Summary = "Cac shipment khu Quan 7 dang co ETA cao hon 24 phut so voi trung binh.", Severity = NotificationSeverity.Info, Link = "/delivery", CreatedAt = DateTimeOffset.UtcNow.AddHours(-2) }
        ]);
    }
}



