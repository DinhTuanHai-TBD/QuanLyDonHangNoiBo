using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public AuditLog AddAuditLog(AuditLog auditLog)
    {
        lock (_sync)
        {
            _auditLogs.Add(auditLog);
        }

        return auditLog;
    }
}



