
namespace QuanLyDonHangNoiBo.Application.Interfaces;


public partial interface IOmsRepository
{
    IReadOnlyList<ExportJob> ExportJobs { get; }
    ExportJob AddExportJob(ExportJob exportJob);
}

