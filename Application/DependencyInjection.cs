using System.Reflection;
using Application.Common.Interfaces.IInstallers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public class DependencyInjection : IInstaller
{
    public void InstallerService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddMediatR(e => e.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}