using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class PickListItemConfiguration : IEntityTypeConfiguration<PickListItem>
{
    public void Configure(EntityTypeBuilder<PickListItem> entity)
    {
        entity.ToTable("PickListItems");
        entity.HasKey(item => item.Id);
        entity.Ignore(item => item.IsCompleted);
        entity.Property(item => item.SkuCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Barcode).HasMaxLength(128);
        entity.Property(item => item.ProductName).HasMaxLength(300).IsRequired();
        entity.HasOne<ProductSku>().WithMany().HasForeignKey(item => item.SkuId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.PickListId, item.SkuId });
        entity.HasIndex(item => item.Barcode);
    }
}

