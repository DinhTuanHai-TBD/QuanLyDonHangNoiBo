using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class InventoryTransactionConfiguration : IEntityTypeConfiguration<InventoryTransaction>
{
    public void Configure(EntityTypeBuilder<InventoryTransaction> entity)
    {
        entity.ToTable("InventoryTransactions");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Type).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.ReferenceCode).HasMaxLength(128);
        entity.Property(item => item.Note).HasMaxLength(1000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Warehouse>().WithMany().HasForeignKey(item => item.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<ProductSku>().WithMany().HasForeignKey(item => item.SkuId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.WarehouseId, item.SkuId, item.CreatedAt });
        entity.HasIndex(item => new { item.TenantId, item.ReferenceCode });
    }
}

