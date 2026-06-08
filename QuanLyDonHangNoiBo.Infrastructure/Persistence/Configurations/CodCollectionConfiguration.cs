using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class CodCollectionConfiguration : IEntityTypeConfiguration<CodCollection>
{
    public void Configure(EntityTypeBuilder<CodCollection> entity)
    {
        entity.ToTable("CodCollections");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.ExpectedAmount).HasPrecision(18, 2);
        entity.Property(item => item.CollectedAmount).HasPrecision(18, 2);
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Order>().WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.DriverId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.Status, item.CollectedAt });
        entity.HasIndex(item => new { item.TenantId, item.OrderId }).IsUnique();
    }
}

