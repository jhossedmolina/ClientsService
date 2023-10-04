namespace ClientsService.Core.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public int IdDocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string Address { get; set; } = null!;
    }
}
