using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ProjectFactory
{
    public static Project ToModel(ProjectEntity entity)
    {
        return entity == null ? null! : new Project
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            CreatedAt = entity.CreatedAt,
            Budget = entity.Budget,
            Client = ClientFactory.ToModel(entity.Client),
            Status = StatusFactory.ToModel(entity.Status),
            User = UserFactory.ToModel(entity.User),
        };
    }

    public static ProjectEntity ToEntity(AddProjectFormData model)
    {
        return model == null ? null! : new ProjectEntity
        {
            ProjectName = model.ProjectName,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Budget = model.Budget,
            ClientId = model.ClientId,
            StatusId = 1,
            UserId = model.UserId,
        };
    }

    public static ProjectEntity ToEntity(UpdateProjectFormData model)
    {
        return model == null ? null! : new ProjectEntity
        {
            Id = model.Id,
            ProjectName = model.ProjectName,
            Description = model.Description,
            StartDate = model.StartDate,
            EndDate = model.EndDate,
            Budget = model.Budget,
            ClientId = model.ClientId,
            StatusId = model.StatusId,
            UserId = model.UserId,
        };
    }
}
