using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Repository.Data;
using Repository.Repositories.Interface.Generic;
using System.Linq.Expressions;

namespace Repository.Repositories.Generic;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;
    private DbSet<T> _table;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _table = _context.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _table.Remove(entity);
        await _context.SaveChangesAsync();

    }

    public IQueryable<T> GetAll(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        IQueryable<T> query = _table;

        if (ignoreQueryFilter)
            query = query.IgnoreQueryFilters();

        if (asNotTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);


        return query;
    }

    public async Task<T?> GetAsync(int id, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        IQueryable<T> query = _table;

        if (ignoreQueryFilter)
            query = query.IgnoreQueryFilters();

        if (asNotTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);

        var entity = await query.FirstOrDefaultAsync(x => x.Id == id);

        return entity;
    }


    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        IQueryable<T> query = _table;

        if (ignoreQueryFilter)
            query = query.IgnoreQueryFilters();

        if (asNotTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);

        var entity = await query.FirstOrDefaultAsync(expression);

        return entity;
    }

    public IQueryable<T> GetFilter(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool ignoreQueryFilter = false, bool asNotTracking = true)
    {
        IQueryable<T> query = _table.Where(expression);

        if (ignoreQueryFilter)
            query = query.IgnoreQueryFilters();

        if (asNotTracking)
            query = query.AsNoTracking();

        if (include is { })
            query = include(query);

        return query;
    }

    public IQueryable<T> OrderByQuery(IQueryable<T> query, Expression<Func<T, object>> expression)
    {
        query = query.OrderBy(expression);

        return query;
    }


    public IQueryable<T> OrderByDescendingQuery(IQueryable<T> query, Expression<Func<T, object>> expression)
    {
        query = query.OrderByDescending(expression);

        return query;
    }

    public IQueryable<T> PaginateQuery(IQueryable<T> query, int limit, int page)
    {
        query = query.Skip((page - 1) * limit).Take(limit);

        return query;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Update(T entity)
    {
        _table.Update(entity);
    }

    public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
    {
        var result = await _table.AnyAsync(expression);

        return result;
    }
}
