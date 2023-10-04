using ClientsService.Core.Entities;

namespace ClientsService.Core.Interfaces
{
    public interface IDocumentTypeRepository
    {
        IEnumerable<DocumentType> GetAllDocumentTypes();
        Task<DocumentType> GetDocumentTypeById(int id);
        Task PostDocumentType(DocumentType documentType);
        Task<bool> PutDocumentType(DocumentType documentType);
        Task<bool> DeleteDocumentType(int id);
    }
}
