using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Interfaces.IInstallers;

public interface IInstaller
{
    void InstallerService(IServiceCollection serviceCollection, IConfiguration configuration);
}