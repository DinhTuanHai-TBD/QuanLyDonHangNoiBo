using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        entity.ToTable("Orders");
        entity.HasKey(item => item.Id);
        entity.Ignore(item => item.Subtotal);
        entity.Ignore(item => item.Total);
        entity.Property(item => item.OrderCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.PaymentMethod).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.Discount).HasPrecision(18, 2);
        entity.Property(item => item.ShippingFee).HasPrecision(18, 2);
        entity.Property(item => item.CodAmount).HasPrecision(18, 2);
        entity.Property(item => item.DeliveryAddress).HasMaxLength(500);
        entity.Property(item => item.InternalNote).HasMaxLength(1000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Customer>().WithMany().HasForeignKey(item => item.CustomerId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Warehouse>().WithMany().HasForeignKey(item => item.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        entity.HasMany(item => item.Items).WithOne().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Cascade);
        entity.HasIndex(item => new { item.TenantId, item.OrderCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.Status, item.CreatedAt });
        entity.HasIndex(item => new { item.TenantId, item.CustomerId, item.CreatedAt });
        entity.HasIndex(item => new { item.TenantId, item.WarehouseId, item.Status });
    }
}

