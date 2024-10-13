using Application.Common.Interfaces.IInstallers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace IOC.Installers;

public class DbContextInstaller: IInstaller
{
    public void InstallerService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(e => e.UseNpgsql(configuration["ConnectionString:DefaultConnection"],
            o =>
            {
                o.CommandTimeout(60);
                o.EnableRetryOnFailure();
                o.MigrationsAssembly("Persistence");
                o.UseQuerySplittingBehavior(QuerySplittingBehavior.SingleQuery);
            }));
        
    }
}