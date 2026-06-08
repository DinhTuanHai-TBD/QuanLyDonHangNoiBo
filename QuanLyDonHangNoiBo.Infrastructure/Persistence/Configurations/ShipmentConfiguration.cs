using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> entity)
    {
        entity.ToTable("Shipments");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.ShipmentCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.RouteName).HasMaxLength(200);
        entity.Property(item => item.FailureReason).HasMaxLength(500);
        entity.Property(item => item.ProofOfDeliveryUrl).HasMaxLength(1000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Order>().WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.DriverId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.ShipmentCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.DriverId, item.Status });
        entity.HasIndex(item => new { item.TenantId, item.OrderId }).IsUnique();
    }
}

