using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> entity)
    {
        entity.ToTable("OrderItems");
        entity.HasKey(item => item.Id);
        entity.Ignore(item => item.LineTotal);
        entity.Property(item => item.SkuCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.ProductName).HasMaxLength(300).IsRequired();
        entity.Property(item => item.UnitPrice).HasPrecision(18, 2);
        entity.HasOne<ProductSku>().WithMany().HasForeignKey(item => item.SkuId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.OrderId, item.SkuId });
    }
}

