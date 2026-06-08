using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository : IOmsRepository
{
    private readonly object _sync = new();

    private readonly List<Tenant> _tenants = [];

    private readonly List<AppUser> _users = [];

    private readonly List<Customer> _customers = [];

    private readonly List<Product> _products = [];

    private readonly List<ProductSku> _skus = [];

    private readonly List<Warehouse> _warehouses = [];

    private readonly List<InventoryStock> _inventoryStocks = [];

    private readonly List<InventoryTransaction> _inventoryTransactions = [];

    private readonly List<Order> _orders = [];

    private readonly List<OrderStatusHistory> _orderStatusHistories = [];

    private readonly List<PickList> _pickLists = [];

    private readonly List<Package> _packages = [];

    private readonly List<Shipment> _shipments = [];

    private readonly List<ProofOfDelivery> _proofOfDeliveries = [];

    private readonly List<CodCollection> _codCollections = [];

    private readonly List<ReturnRequest> _returns = [];

    private readonly List<NotificationItem> _notifications = [];

    private readonly List<AuditLog> _auditLogs = [];

    private readonly List<AiInsight> _aiInsights = [];

    private readonly List<ExportJob> _exportJobs = [];

    public InMemoryOmsRepository()
    {
        Seed();
    }

    public IReadOnlyList<Tenant> Tenants => _tenants;

    public IReadOnlyList<AppUser> Users => _users;

    public IReadOnlyList<Customer> Customers => _customers;

    public IReadOnlyList<Product> Products => _products;

    public IReadOnlyList<ProductSku> Skus => _skus;

    public IReadOnlyList<Warehouse> Warehouses => _warehouses;

    public IReadOnlyList<InventoryStock> InventoryStocks => _inventoryStocks;

    public IReadOnlyList<InventoryTransaction> InventoryTransactions => _inventoryTransactions;

    public IReadOnlyList<Order> Orders => _orders;

    public IReadOnlyList<OrderStatusHistory> OrderStatusHistories => _orderStatusHistories;

    public IReadOnlyList<PickList> PickLists => _pickLists;

    public IReadOnlyList<Package> Packages => _packages;

    public IReadOnlyList<Shipment> Shipments => _shipments;

    public IReadOnlyList<ProofOfDelivery> ProofOfDeliveries => _proofOfDeliveries;

    public IReadOnlyList<CodCollection> CodCollections => _codCollections;

    public IReadOnlyList<ReturnRequest> Returns => _returns;

    public IReadOnlyList<NotificationItem> Notifications => _notifications;

    public IReadOnlyList<AuditLog> AuditLogs => _auditLogs;

    public IReadOnlyList<AiInsight> AiInsights => _aiInsights;

    public IReadOnlyList<ExportJob> ExportJobs => _exportJobs;
}



