using AutoMapper;
using ClientsService.Core.DTOs;
using ClientsService.Core.Entities;

namespace ClientsService.Infraestructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();
        }
    }
}
