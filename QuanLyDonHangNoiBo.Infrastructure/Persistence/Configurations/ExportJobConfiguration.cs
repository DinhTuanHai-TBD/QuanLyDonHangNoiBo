using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class ExportJobConfiguration : IEntityTypeConfiguration<ExportJob>
{
    public void Configure(EntityTypeBuilder<ExportJob> entity)
    {
        entity.ToTable("ExportJobs");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.ExportCode).HasMaxLength(64).IsRequired();
        entity.Property(item => item.ExportType).HasMaxLength(64).IsRequired();
        entity.Property(item => item.Status).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.FileName).HasMaxLength(260);
        entity.Property(item => item.DownloadUrl).HasMaxLength(1000);
        entity.Property(item => item.Summary).HasMaxLength(2000);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasOne<AppUser>().WithMany().HasForeignKey(item => item.RequestedByUserId).OnDelete(DeleteBehavior.SetNull);
        entity.HasIndex(item => new { item.TenantId, item.ExportCode }).IsUnique();
        entity.HasIndex(item => new { item.TenantId, item.ExportType, item.CreatedAt });
    }
}

