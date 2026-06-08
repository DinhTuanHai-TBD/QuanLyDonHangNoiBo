using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class ProductSkuConfiguration : IEntityTypeConfiguration<ProductSku>
{
    public void Configure(EntityTypeBuilder<ProductSku> entity)
    {
        entity.ToTable("ProductSkus");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.SkuCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Barcode).HasMaxLength(128);
        entity.Property(item => item.Name).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Unit).HasMaxLength(32).IsRequired();
        entity.Property(item => item.Price).HasPrecision(18, 2);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.SkuCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.Barcode });
    }
}

