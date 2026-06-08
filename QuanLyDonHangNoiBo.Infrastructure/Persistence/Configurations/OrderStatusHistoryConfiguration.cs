using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class OrderStatusHistoryConfiguration : IEntityTypeConfiguration<OrderStatusHistory>
{
    public void Configure(EntityTypeBuilder<OrderStatusHistory> entity)
    {
        entity.ToTable("OrderStatusHistories");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.OldStatus).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.NewStatus).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.Note).HasMaxLength(1000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Order>().WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Cascade);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.ChangedByUserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.OrderId, item.ChangedAt });
    }
}

