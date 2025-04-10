using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProjectService(ProjectRepo projectRepo)
{
    private readonly ProjectRepo _projectRepo = projectRepo;
}

