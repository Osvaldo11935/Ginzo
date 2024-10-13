using Application.Common.Interfaces.IInstallers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IOC;

public static class Installer
{
    public static void InstallerService(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        var installers = new List<IInstaller>();

        foreach (var assembly in assemblies)
        {
            var assemblyInstaller = assembly.GetTypes()
                .Where(e => typeof(IInstaller).IsAssignableFrom(e) && !e.IsInterface && !e.IsAbstract)
                .Select(e => (IInstaller)Activator.CreateInstance(e)!).ToList();
            
            installers.AddRange(assemblyInstaller);
        }
        installers.ForEach(e => e.InstallerService(serviceCollection, configuration));
    }
}