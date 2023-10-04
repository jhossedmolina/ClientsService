using ClientsService.Core.Entities;
using ClientsService.Core.Interfaces;
using ClientsService.Infraestructure.Data;

namespace ClientsService.Infraestructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ClientsDBContext _context;

        public ClientRepository(ClientsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public async Task<Client> GetClientById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task PostClient(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> PutClient(Client client)
        {
            var currentClient = await GetClientById(client.Id);
            currentClient.IdDocumentType = client.IdDocumentType;
            currentClient.DocumentNumber = client.DocumentNumber;
            currentClient.Name = client.Name;
            currentClient.PhoneNumber = client.PhoneNumber;
            currentClient.Email = client.Email;
            currentClient.Address = client.Address;

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var currentClient = await GetClientById(id);
            _context.Clients.Remove(currentClient);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
