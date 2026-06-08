using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.ToTable("Products");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Code).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Name).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Category).HasMaxLength(100);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasMany(item => item.Skus).WithOne().HasForeignKey(item => item.ProductId).OnDelete(DeleteBehavior.Cascade);
        entity.HasIndex(item => new { item.TenantId, item.Code }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.Name });
    }
}

