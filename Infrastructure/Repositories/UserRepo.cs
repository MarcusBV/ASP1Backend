using Infrastructure.Data.Contexts;
using Infrastructure.Data.Entities;

namespace Infrastructure.Repositories;

public interface IUserRepo : IBaseRepo<UserEntity>
{

}

public class UserRepo(DataContext context) : BaseRepo<UserEntity>(context), IUserRepo
{
}
