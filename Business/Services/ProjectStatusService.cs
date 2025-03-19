using Business.Factories;
using Data.Repositories;
using Domain.Models;

namespace Business.Services
{
    public class ProjectStatusService(ProjectStatusRepository statusRepository)
    {
        private readonly ProjectStatusRepository _projectStatusRepository = statusRepository;

        public async Task<IEnumerable<ProjectStatus>> GetProjectStatuses()
        {
            var list = await _projectStatusRepository.GetAllAsync<ProjectStatus>(
                selector: x => ProjectStatusFactory.Map(x)
            );

            return list;
        }
    }
}
