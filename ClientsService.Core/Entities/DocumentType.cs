namespace ClientsService.Core.Entities
{
    public partial class DocumentType
    {
        public DocumentType()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<Client> Clients { get; set; }
    }
}
