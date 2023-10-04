using ClientsService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientsService.Infraestructure.Data.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");

            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.Email)
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.HasOne(d => d.IdDocumentTypeNavigation)
                .WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdDocumentType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Client_DocumentType");
        }
    }
}
