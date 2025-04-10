using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class UserService(UserRepo userRepo)
{
    private readonly UserRepo _userRepo = userRepo;

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        var entities = await _userRepo.GetAllAsync();
        var users = entities.Select(UserFactory.ToModel);
        return users;
    }
}

