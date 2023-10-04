using ClientsService.Core.Entities;
using ClientsService.Core.Interfaces;
using ClientsService.Infraestructure.Data;

namespace ClientsService.Infraestructure.Repositories
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly ClientsDBContext _context;

        public DocumentTypeRepository(ClientsDBContext context)
        {
            _context = context;
        }

        public IEnumerable<DocumentType> GetAllDocumentTypes()
        {
            return _context.DocumentTypes.ToList();
        }

        public async Task<DocumentType> GetDocumentTypeById(int id)
        {
            return await _context.DocumentTypes.FindAsync(id);
        }

        public async Task PostDocumentType(DocumentType documentType)
        {
            _context.DocumentTypes.Add(documentType);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> PutDocumentType(DocumentType documentType)
        {
            var currentDocumentType = await GetDocumentTypeById(documentType.Id);
            currentDocumentType.Code = documentType.Code;
            currentDocumentType.Name = documentType.Name;

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteDocumentType(int id)
        {
            var currentDocumentType = await GetDocumentTypeById(id);
            _context.DocumentTypes.Remove(currentDocumentType);

            var rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
