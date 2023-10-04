using ClientsService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientsService.Infraestructure.Data.Configurations
{
    public class DocumentTypeConfiguration : IEntityTypeConfiguration<DocumentType>
    {
        public void Configure(EntityTypeBuilder<DocumentType> builder)
        {
            builder.ToTable("DocumentType");

            builder.Property(e => e.Code)
                .HasMaxLength(3)
                .IsUnicode(false);

            builder.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
