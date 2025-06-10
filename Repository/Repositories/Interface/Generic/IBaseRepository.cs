using Domain.Common;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Repository.Repositories.Interface.Generic;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
    IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
    IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true);
    Task CreateAsync(T entity);
    void Update(T entity);
    Task Delete(T entity);
    Task<int> SaveChangesAsync();
    Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
    IQueryable<T> PaginateQuery(IQueryable<T> query, int limit, int page);
    IQueryable<T> OrderByQuery(IQueryable<T> query, Expression<Func<T, object>> expression);
    IQueryable<T> OrderByDescendingQuery(IQueryable<T> query, Expression<Func<T, object>> expression);
}
