using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class StatusFactory
{
    public static Status ToModel(StatusEntity entity)
    {
        return entity == null ? null! : new Status
        {
            Id = entity.Id,
            StatusName = entity.StatusName
        };
    }
}
