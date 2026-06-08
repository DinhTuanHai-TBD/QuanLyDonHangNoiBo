using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class NotificationItemConfiguration : IEntityTypeConfiguration<NotificationItem>
{
    public void Configure(EntityTypeBuilder<NotificationItem> entity)
    {
        entity.ToTable("Notifications");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Title).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Message).HasMaxLength(1000).IsRequired();
        entity.Property(item => item.Severity).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.Link).HasMaxLength(500);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.UserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.UserId, item.IsRead, item.CreatedAt });
    }
}

