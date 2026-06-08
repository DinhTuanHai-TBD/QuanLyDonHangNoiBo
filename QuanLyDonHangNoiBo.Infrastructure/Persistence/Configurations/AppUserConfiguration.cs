using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> entity)
    {
        entity.ToTable("Users");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.FullName).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Email).HasMaxLength(256).IsRequired();
        entity.Property(item => item.PasswordHash).HasMaxLength(512).IsRequired();
        entity.Property(item => item.Role).HasConversion<string>().HasMaxLength(64).IsRequired();
        entity.Property(item => item.Locale).HasMaxLength(10).IsRequired();
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Warehouse>().WithMany().HasForeignKey(item => item.WarehouseId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.Email }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.Role, item.IsActive });
    }
}

