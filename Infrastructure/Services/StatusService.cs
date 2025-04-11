using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StatusService(StatusRepo statusRepo)
{
    private readonly StatusRepo _statusRepo = statusRepo;

    public async Task<IEnumerable<Status>> GetAllStatusesAsync()
    {
        var entities = await _statusRepo.GetAllAsync();
        var statuses = entities.Select(StatusFactory.ToModel);
        return statuses;
    }

    public async Task<Status?> GetStatusByIdAsync(int id)
    {
        var result = await _statusRepo.GetAsync(x => x.Id == id);
        return result == null ? null : StatusFactory.ToModel(result);
    }
}