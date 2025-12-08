using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Tablo adı ve şema
            builder.ToTable("Categories", "app");

            // Birincil anahtar
            builder.HasKey(x => x.Id);

            // Id property ayarları
            builder.Property(x => x.Id)
                   .HasMaxLength(36);

            // Silinme durumu property'si
            builder.Property(x => x.IsDeleted)
                   .IsRequired()
                   .HasDefaultValue(false);

            // Oluşturulma zamanı property'si
            builder.Property(x => x.CreatedOn)
                   .IsRequired()
                   .ValueGeneratedOnAdd();

            // Global query filter: sadece silinmemiş kayıtları getir
            builder.HasQueryFilter(x => !x.IsDeleted);

            // Name property'si
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(256);

            // Name için benzersiz index
            builder.HasIndex(x => x.Name)
                   .IsUnique();
        }
    }
}
