using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class PickListConfiguration : IEntityTypeConfiguration<PickList>
{
    public void Configure(EntityTypeBuilder<PickList> entity)
    {
        entity.ToTable("PickLists");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.PickListCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Order>().WithMany().HasForeignKey(item => item.OrderId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<Warehouse>().WithMany().HasForeignKey(item => item.WarehouseId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.AssignedToUserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasMany(item => item.Items).WithOne().HasForeignKey(item => item.PickListId).OnDelete(DeleteBehavior.Cascade);
        entity.HasIndex(item => new { item.TenantId, item.PickListCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.WarehouseId, item.Status });
        entity.HasIndex(item => new { item.TenantId, item.OrderId });
    }
}

