using ClientsService.Core.Entities;

namespace ClientsService.Core.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Task<Client> GetClientById(int id);
        Task PostClient(Client client);
        Task<bool> PutClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}
