using AutoMapper;
using ClientsService.Core.DTOs;
using ClientsService.Core.Entities;
using ClientsService.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace ClientsService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeController(IMapper mapper, IDocumentTypeRepository documentTypeRepository)
        {
            _mapper = mapper;
            _documentTypeRepository = documentTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDocumentTypes()
        {
            var documentTypes = _documentTypeRepository.GetAllDocumentTypes();
            var documentTypesDto = _mapper.Map<IEnumerable<DocumentTypeDto>>(documentTypes);
            return Ok(documentTypesDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetDocumentTypeById(int id)
        {
            var documentType = await _documentTypeRepository.GetDocumentTypeById(id);
            var documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            if (documentTypeDto == null)
            {
                return NotFound();
            }
            return Ok(documentTypeDto);
        }

        [HttpPost]
        public async Task<ActionResult> InsertDocumentType(DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            await _documentTypeRepository.PostDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDocumentType(int id, DocumentTypeDto documentTypeDto)
        {
            var documentType = _mapper.Map<DocumentType>(documentTypeDto);
            documentType.Id = id;
            await _documentTypeRepository.PutDocumentType(documentType);
            documentTypeDto = _mapper.Map<DocumentTypeDto>(documentType);
            return Ok(documentTypeDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDocumentType(int id)
        {
            var result = await _documentTypeRepository.DeleteDocumentType(id);
            return Ok(result);
        }
    }
}
