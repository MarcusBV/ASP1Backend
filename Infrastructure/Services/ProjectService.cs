using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ProjectService(ProjectRepo projectRepo)
{
    private readonly ProjectRepo _projectRepo = projectRepo;


    public async Task<bool> CreateProjectAsync(AddProjectFormData formData)
    {
        if (formData == null)
            return false;

        var project = ProjectFactory.ToEntity(formData);

        var result = await _projectRepo.AddAsync(project);
        return result;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool orderByDescending = false)
    {
        var entities = await _projectRepo.GetAllAsync();
        var projects = entities.Select(ProjectFactory.ToModel);

        return orderByDescending == true ? projects.OrderByDescending(entity => entity.CreatedAt) : projects.OrderBy(entity => entity.CreatedAt);
    }

    public async Task<Project?> GetProjectById(string projectId)
    {
        var entity = await _projectRepo.GetAsync(x => x.Id == projectId);
        return entity == null ? null : ProjectFactory.ToModel(entity);
    }

    public async Task<bool> UpdateProjectAsync(UpdateProjectFormData formData)
    {
        if (formData == null)
            return false;

        var project = ProjectFactory.ToEntity(formData);

        var result = await _projectRepo.UpdateAsync(project);
        return result;
    }

    public async Task<bool> DeleteProjectAsync(string projectId)
    {
        if (string.IsNullOrEmpty(projectId))
            return false;

        var result = await _projectRepo.DeleteAsync(x => x.Id == projectId);
        return result;
    }
}