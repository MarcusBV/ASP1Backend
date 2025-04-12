using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class BaseRepo<TEntity> where TEntity : class
{
    protected readonly DataContext _context;
    protected readonly DbSet<TEntity> _table;

    public BaseRepo(DataContext context)
    {
        _context = context;
        _table = _context.Set<TEntity>();
    }

    public virtual async Task<bool> AddAsync(TEntity entity)
    {
        if (entity == null)
            return false;

        try
        {
            await _table.AddAsync(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var entities = await _table.ToListAsync();
        return entities;
    }

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        var entity = await _table.FirstOrDefaultAsync(expression);
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(TEntity entity)
    {
        if (entity == null)
            return false;

        try
        {
            _table.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public virtual async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        if (expression == null)
            return false;

        var entity = await _table.FirstOrDefaultAsync(expression);
        if (entity == null)
            return false;

        _table.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
}
