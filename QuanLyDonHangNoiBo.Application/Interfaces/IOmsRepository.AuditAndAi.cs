
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<AuditLog> AuditLogs { get; }
    IReadOnlyList<AiInsight> AiInsights { get; }
    AuditLog AddAuditLog(AuditLog auditLog);
}

