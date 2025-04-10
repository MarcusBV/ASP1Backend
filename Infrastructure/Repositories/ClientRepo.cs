using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public class ClientRepo(DataContext context) : BaseRepo<ClientEntity>(context)
{
}
