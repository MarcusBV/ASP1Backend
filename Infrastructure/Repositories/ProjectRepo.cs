using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public class ProjectRepo(DataContext context) : BaseRepo<ProjectEntity>(context)
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        var entities = await _table
            .Include(x => x.User)
            .Include(x => x.Status)
            .Include(x => x.Client)
            .ToListAsync();

        return entities;
    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        var entity = await _table
            .Include(x => x.User)
            .Include(x => x.Status)
            .Include(x => x.Client)
            .FirstOrDefaultAsync(expression);

        return entity;
    }
}
