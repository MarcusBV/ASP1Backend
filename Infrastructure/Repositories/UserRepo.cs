using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public class UserRepo(DataContext context) : BaseRepo<UserEntity>(context)
{
}
