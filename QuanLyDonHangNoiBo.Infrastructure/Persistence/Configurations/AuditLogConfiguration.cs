using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> entity)
    {
        entity.ToTable("AuditLogs");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.EntityName).HasMaxLength(128).IsRequired();
        entity.Property(item => item.EntityId).HasMaxLength(128).IsRequired();
        entity.Property(item => item.Action).HasMaxLength(128).IsRequired();
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.UserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.EntityName, item.EntityId, item.CreatedAt });
        entity.HasIndex(item => new { item.TenantId, item.UserId, item.CreatedAt });
    }
}

