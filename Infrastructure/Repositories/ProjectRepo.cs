using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public class ProjectRepo(DataContext context) : BaseRepo<ProjectEntity>(context)
{
}
