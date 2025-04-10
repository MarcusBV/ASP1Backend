using Infrastructure.Factories;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class ClientService(ClientRepo clientRepo)
{
    private readonly ClientRepo _clientRepo = clientRepo;

    public async Task<IEnumerable<Client>> GetAllClientsAsync()
    {
        var entities = await _clientRepo.GetAllAsync();
        var clients = entities.Select(ClientFactory.ToModel);
        return clients;
    }
}

