using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuanLyDonHangNoiBo.Domain.Entities;

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Configurations;

public sealed class AiInsightConfiguration : IEntityTypeConfiguration<AiInsight>
{
    public void Configure(EntityTypeBuilder<AiInsight> entity)
    {
        entity.ToTable("AIInsights");
        entity.HasKey(item => item.Id);
        entity.Property(item => item.Title).HasMaxLength(200).IsRequired();
        entity.Property(item => item.Summary).HasMaxLength(2000).IsRequired();
        entity.Property(item => item.Severity).HasConversion<string>().HasMaxLength(32).IsRequired();
        entity.Property(item => item.Link).HasMaxLength(500);
        entity.HasOne<Tenant>().WithMany().HasForeignKey(item => item.TenantId).OnDelete(DeleteBehavior.Restrict);
        entity.HasIndex(item => new { item.TenantId, item.Severity, item.CreatedAt });
    }
}

