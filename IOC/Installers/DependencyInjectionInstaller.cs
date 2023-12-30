using Application.Common.Interfaces.IInstallers;
using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Common.UnitOfWorks;
using Persistence.Repositories;

namespace IOC.Installers;

public class DependencyInjectionInstaller: IInstaller
{
    public void InstallerService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddTransient<IUserRepository, UserRepository>();
    }
}