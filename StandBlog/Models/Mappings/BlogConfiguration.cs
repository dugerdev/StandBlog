using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            // Tablo adı ve şema
            builder.ToTable("Blogs", "app");

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

            // Title property ayarları
            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(256);

            // Title için benzersiz index
            builder.HasIndex(x => x.Title)
                   .IsUnique();

            // Post property ayarları
            builder.Property(x => x.Post)
                   .IsRequired()
                   .HasColumnType("ntext");

            // İlişki: Blog -> Category
            builder.HasOne(b => b.Category)
                   .WithMany(c => c.Blogs)
                   .HasForeignKey(b => b.CategoryId);
        }
    }
}
