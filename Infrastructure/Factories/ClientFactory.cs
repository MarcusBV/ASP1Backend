using Infrastructure.Data.Entities;
using Infrastructure.Models;

namespace Infrastructure.Factories;

public class ClientFactory
{
    public static Client ToModel(ClientEntity entity)
    {
        return entity == null ? null! : new Client
        {
            Id = entity.Id,
            ClientName = entity.ClientName
        };
    }
}
