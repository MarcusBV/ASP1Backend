using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public class StatusRepo(DataContext context) : BaseRepo<StatusEntity>(context)
{
}