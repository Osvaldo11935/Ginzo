using Application.Common.Interfaces.IRepositories;
using Domain.Entities.Common;

namespace Application.Common.Interfaces.IUnitOfWorks;

public interface IUnitOfWork
{
    #region Repositories

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public IGenericRepository<T> AsyncRepository<T>()
        where T : EntityBase;

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public IUserRepository UserRepository();
    #endregion
    
    #region SaveChange

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<int> SaveChangeAsync(CancellationToken cancellationToken);

    #endregion
}