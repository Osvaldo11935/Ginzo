using System.Linq.Expressions;

namespace Application.Common.Interfaces.IRepositories;

public interface IGenericRepository<T>
 where T: class
{
     #region Write

     /// <summary>
     /// 
     /// </summary>
     /// <param name="request"></param>
     Task InsertAsync(T request);
     
     /// <summary>
     /// 
     /// </summary>
     /// <param name="request"></param>
     Task InsertAsync(List<T> request);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    void Update(T request);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    void Remove(T request);

    #endregion

    #region Read

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    IQueryable<T> SelectAllAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? expression = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    IQueryable<T> SelectAllAsync(Expression<Func<T, bool>>? expression = default);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includes"></param>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    Task<T> SelectAsync(Expression<Func<T, bool>>? predicate = null, List<Expression<Func<T, object>>>? includes = null,
        bool disableTracking = true);

    #endregion
}