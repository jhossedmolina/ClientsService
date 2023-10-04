using AutoMapper;
using ClientsService.Core.DTOs;
using ClientsService.Core.Entities;
using ClientsService.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientController(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ClientDto>> GetAllClients()
        {
            var clients = _clientRepository.GetAllClients();
            var clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return Ok(clientsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetClientById(int id)
        {
            var client = await _clientRepository.GetClientById(id);
            var clientDto = _mapper.Map<ClientDto>(client);
            if (clientDto == null)
            {
                return NotFound();
            }
            return Ok(clientDto);
        }

        [HttpPost]
        public async Task<ActionResult> InsertClient(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _clientRepository.PostClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateClient(int id, ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            client.Id = id;
            await _clientRepository.PutClient(client);
            clientDto = _mapper.Map<ClientDto>(client);
            return Ok(clientDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(int id)
        {
            var result = await _clientRepository.DeleteClient(id);
            return Ok(result);
        }
    }
}
