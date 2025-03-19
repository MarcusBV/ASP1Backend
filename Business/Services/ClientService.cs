using Data.Repositories;
using Domain.Models;

namespace Business.Services
{
    public class ClientService(ClientRepository clientRepository)
    {
        private readonly ClientRepository _clientRepository = clientRepository;

        public async Task<ServiceResult> CreateAsync(ClientRegistrationForm form)
        {
            if (form == null)
                return ServiceResult.BadRequest();

            if (await _clientRepository.ExistsAsync(x => x.ClientName == form.ClientName))
                return ServiceResult.AlreadyExists();

            try
            {
                var clientEntity = ClientFactory.Create(form);
                var result = await _clientRepository.AddAsync(clientEntity);
                if(result)
                {
                    return ServiceResult.Created();
                }
            }
            catch
            {
            //catch
            return ServiceResult.Failed();
            }

        }
    }
}
