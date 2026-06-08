using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class InventoryStockConfiguration : IEntityTypeConfiguration<InventoryStock>
{
    public void Configure(EntityTypeBuilder<InventoryStock> entity)
    {
        entity.ToTable("InventoryStocks");
        entity.HasKey(item => item.Id);
        entity.Ignore(item => item.Available);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Warehouse>().WithMany().HasForeignKey(item => item.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<ProductSku>().WithMany().HasForeignKey(item => item.SkuId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.WarehouseId, item.SkuId }).IsUnique();
    }
}

