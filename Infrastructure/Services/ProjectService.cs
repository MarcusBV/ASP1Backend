using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProjectService(ProjectRepo projectRepo)
{
    private readonly ProjectRepo _projectRepo = projectRepo;

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool orderByDescending = false)
    {
        var entities = await _projectRepo.GetAllAsync();
        var projects = entities.Select(ProjectFactory.ToModel);

        return orderByDescending == true ?
            entities.
    }
}

