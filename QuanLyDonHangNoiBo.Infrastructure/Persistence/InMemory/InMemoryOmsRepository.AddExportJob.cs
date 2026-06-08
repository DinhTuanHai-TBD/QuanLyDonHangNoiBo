using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Domain.Entities;
using QuanLyDonHangNoiBo.Domain.Enums;
namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

public sealed partial class InMemoryOmsRepository
{
    public ExportJob AddExportJob(ExportJob exportJob)
    {
        lock (_sync)
        {
            _exportJobs.Add(exportJob);
        }

        return exportJob;
    }
}



