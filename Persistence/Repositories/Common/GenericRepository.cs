using System.Linq.Expressions;
using Application.Common.Interfaces.IRepositories;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.Common;

public class GenericRepository<T>: IGenericRepository<T>
  where T : EntityBase
{
    #region Properties and builders

    private readonly DbSet<T> _dbSet;

    public GenericRepository(ApplicationDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    #endregion

    #region Write
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    public async Task InsertAsync(T request)
        => await _dbSet.AddAsync(request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    public async Task InsertAsync(List<T> request)
        => await _dbSet.AddRangeAsync(request);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    public void Update(T request)
        =>  _dbSet.Update(request);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    public void Remove(T request)
        => _dbSet.Remove(request);

    #endregion

    #region Read
    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
        => await _dbSet.AnyAsync(predicate!);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pageNumber"></param>
    /// <param name="pageSize"></param>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IQueryable<T> SelectAllAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? expression = default)
    {
        if (expression != null)
        {
            return _dbSet.Where(expression)
                .OrderBy(e => e.CreatedAt)
                .Skip((pageNumber - 1) * pageSize).Take(pageSize)
                .AsNoTracking();
        }
        return _dbSet
            .OrderBy(e => e.CreatedAt)
            .Skip((pageNumber - 1) * pageSize).Take(pageSize)
            .AsNoTracking();
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IQueryable<T> SelectAllAsync(Expression<Func<T, bool>>? expression = default)
    {
        if (expression != null)
        {
            return _dbSet.Where(expression)
                .OrderBy(e => e.CreatedAt)
                .AsNoTracking();
        }
        return _dbSet
            .OrderBy(e => e.CreatedAt)
            .AsNoTracking();
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="predicate"></param>
    /// <param name="includes"></param>
    /// <param name="disableTracking"></param>
    /// <returns></returns>
    public async Task<T> SelectAsync(Expression<Func<T, bool>>? predicate = null,  List<Expression<Func<T, object>>>? includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = _dbSet;
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);
        
        return (await query.FirstOrDefaultAsync())!;
    }
    
    #endregion
}