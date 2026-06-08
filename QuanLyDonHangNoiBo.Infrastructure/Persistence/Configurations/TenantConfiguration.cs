using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class TenantConfiguration : IEntityTypeConfiguration<Tenant>
{
    public void Configure(EntityTypeBuilder<Tenant> entity)
    {
        entity.ToTable("Tenants");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Code).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Name).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Plan).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.DefaultLocale).HasMaxLength(10).IsRequired();
        entity.HasIndex(item => item.Code).IsUnique();
        entity.HasIndex(item => item.Status);
    }
}

