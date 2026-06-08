using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class ReturnRequestConfiguration : IEntityTypeConfiguration<ReturnRequest>
{
    public void Configure(EntityTypeBuilder<ReturnRequest> entity)
    {
        entity.ToTable("Returns");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.ReturnCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.Reason).HasMaxLength(1000);
        entity.Property(item => item.RefundAmount).HasPrecision(18, 2);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Order>().WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.ApprovedByUserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.ReturnCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.Status, item.CreatedAt });
    }
}

