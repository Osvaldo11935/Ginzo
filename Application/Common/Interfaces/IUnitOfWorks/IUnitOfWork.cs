using Application.Common.Interfaces.IRepositories;

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
        where T : class;

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