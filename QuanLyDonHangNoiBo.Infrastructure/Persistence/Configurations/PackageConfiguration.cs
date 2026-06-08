using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class PackageConfiguration : IEntityTypeConfiguration<Package>
{
    public void Configure(EntityTypeBuilder<Package> entity)
    {
        entity.ToTable("Packages");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.PackageCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.WeightKg).HasPrecision(18, 2);
        entity.Property(item => item.LengthCm).HasPrecision(18, 2);
        entity.Property(item => item.WidthCm).HasPrecision(18, 2);
        entity.Property(item => item.HeightCm).HasPrecision(18, 2);
        entity.Property(item => item.LabelUrl).HasMaxLength(1000);
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Order>().WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.PackageCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.OrderId });
    }
}

