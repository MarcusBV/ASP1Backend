using Infrastructure.Repositories;

namespace Infrastructure.Services;

public class StatusService(StatusRepo statusRepo)
{
    private readonly StatusRepo _statusRepo = statusRepo;
}

