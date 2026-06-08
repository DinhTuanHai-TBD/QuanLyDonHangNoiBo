using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class ProofOfDeliveryConfiguration : IEntityTypeConfiguration<ProofOfDelivery>
{
    public void Configure(EntityTypeBuilder<ProofOfDelivery> entity)
    {
        entity.ToTable("ProofOfDeliveries");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.ImageUrl).HasMaxLength(1000).IsRequired();
        entity.Property(item => item.ReceiverName).HasMaxLength(200);
        entity.Property(item => item.Note).HasMaxLength(1000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Shipment>().WithMany().HasForeignKey(item => item.ShipmentId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.UploadedByUserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.ShipmentId, item.CapturedAt });
    }
}

