using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyDonHangNoiBo.Application.Interfaces;
using QuanLyDonHangNoiBo.Infrastructure.Persistence.DbContext;
using QuanLyDonHangNoiBo.Infrastructure.Persistence.InMemory;

namespace QuanLyDonHangNoiBo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IOmsRepository, InMemoryOmsRepository>();
        services.AddInfrastructurePersistence(configuration.GetConnectionString("DefaultConnection"));

        return services;
    }

    // ÄÄƒng kĂ½ háº¡ táº§ng persistence riĂªng Ä‘á»ƒ API layer khĂ´ng pháº£i biáº¿t chi tiáº¿t cáº¥u hĂ¬nh EF Core.
    public static IServiceCollection AddInfrastructurePersistence(this IServiceCollection services, string? connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'DefaultConnection' is required.");
        }

        services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        connectionString,
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("QuanLyDonHangNoiBo.Infrastructure");
        }));

        return services;
    }
}








