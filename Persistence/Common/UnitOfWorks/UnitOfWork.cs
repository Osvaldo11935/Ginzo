using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IUnitOfWorks;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.Common;

namespace Persistence.Common.UnitOfWorks;

public class UnitOfWork: IUnitOfWork
{
    #region Properties and builders
    private ApplicationDbContext Context { get; }
    private  RoleManager<Role> RoleManager { get; }
    private  UserManager<User> UserManager { get; }
    
    public UnitOfWork(ApplicationDbContext context, RoleManager<Role> roleManager, UserManager<User> userManager)
    {
        Context = context;
        RoleManager = roleManager;
        UserManager = userManager;
    }
    #endregion
    
    #region Repositories
    
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public IGenericRepository<T> AsyncRepository<T>() 
        where T : class => new GenericRepository<T>(Context);
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IUserRepository UserRepository() 
         => new UserRepository(Context, UserManager, RoleManager);

    #endregion
    
    #region SaveChange
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> SaveChangeAsync(CancellationToken cancellationToken) =>
        await Context.SaveChangesAsync(cancellationToken);

    #endregion
}