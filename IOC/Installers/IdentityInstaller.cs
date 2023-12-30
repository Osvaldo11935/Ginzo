using Application.Common.Interfaces.IInstallers;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace IOC.Installers;

public class IdentityInstaller: IInstaller
{
    public void InstallerService(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDataProtection();
        serviceCollection.AddIdentityCore<User>(e =>{
            e.Password.RequiredLength = 8;
            e.Password.RequireDigit = true;
            e.Password.RequireLowercase = true;
            e.Password.RequireUppercase = true;
            e.Password.RequireNonAlphanumeric = true;
        })
            .AddRoles<Role>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
    }
}