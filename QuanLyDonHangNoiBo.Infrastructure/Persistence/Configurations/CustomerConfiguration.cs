using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> entity)
    {
        entity.ToTable("Customers");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Code).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Name).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Phone).HasMaxLength(32).IsRequired();
        entity.Property(item => item.Email).HasMaxLength(256);
        entity.Property(item => item.Address).HasMaxLength(500);
        entity.Property(item => item.Province).HasMaxLength(100);
        entity.Property(item => item.Segment).HasMaxLength(64);
        entity.Property(item => item.Note).HasMaxLength(1000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.Code }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.Phone });
        entity.HasIndex(item => new { item.TenantId, item.Name });
    }
}

