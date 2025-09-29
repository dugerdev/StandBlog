using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            // Tablo adı ve şema
            builder.ToTable("Contacts", "app");

            // Birincil anahtar
            builder.HasKey(x => x.Id);

            // Id property'si
            builder.Property(x => x.Id)
                   .HasMaxLength(36);

            // Silinme durumu
            builder.Property(x => x.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Oluşturulma zamanı
            builder.Property(x => x.CreatedOn)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            // Global query filter: sadece silinmemiş kayıtları getir
            builder.HasQueryFilter(x => !x.IsDeleted);

            // Name property
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(256);

            // Email property
            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(256);

            // Subject property
            builder.Property(x => x.Subject)
                   .IsRequired()
                   .HasMaxLength(256);

            // Message property
            builder.Property(x => x.Message)
                   .IsRequired()
                   .HasMaxLength(500);
        }
    }
}
