using ClientsService.Core.Entities;
using ClientsService.Infraestructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ClientsService.Infraestructure.Data
{
    public partial class ClientsDBContext : DbContext
    {
        public ClientsDBContext()
        {
        }

        public ClientsDBContext(DbContextOptions<ClientsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClientConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocumentTypeConfiguration).Assembly);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
