using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Tablo adı ve şema
            builder.ToTable("Comments", "app");

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

            // Message property
            builder.Property(x => x.Message)
                   .IsRequired()
                   .HasMaxLength(500);

            // Blog ilişkisi
            builder.HasOne(c => c.Blog)
                   .WithMany(b => b.Comments)
                   .HasForeignKey(c => c.BlogId);
        }
    }
}
