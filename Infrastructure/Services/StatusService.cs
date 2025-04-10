using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StatusService(StatusRepo statusRepo)
{
    private readonly StatusRepo _statusRepo = statusRepo;

    public async Task<IEnumerable<Status>> GetAllStatusesAsync()
    {
        var entities = await _statusRepo.GetAllAsync();
        var statuses = entities.Select(status => new Status { Id = status.Id, StatusName = status.StatusName });
        return statuses;
    }

    public async Task<Status?> GetStatusByIdAsync(int id)
    {
        var result = await _statusRepo.GetAsync(x => x.Id == id);
        return result == null ? null : new Status { Id = result.Id, StatusName = result.StatusName };
    }
}