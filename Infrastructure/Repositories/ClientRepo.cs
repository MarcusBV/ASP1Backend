using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public interface IClientRepo : IBaseRepo<ClientEntity>
{

}

public class ClientRepo(DataContext context) : BaseRepo<ClientEntity>(context), IClientRepo
{
}
