using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public interface IStatusRepo : IBaseRepo<StatusEntity>
{

}

public class StatusRepo(DataContext context) : BaseRepo<StatusEntity>(context), IStatusRepo
{
}