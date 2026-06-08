using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> entity)
    {
        entity.ToTable("Warehouses");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Code).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Name).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Province).HasMaxLength(100);
        entity.Property(item => item.Address).HasMaxLength(500);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.Code }).IsUnique();
    }
}

