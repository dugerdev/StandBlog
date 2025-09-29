using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            // Tablo adı ve şema
            builder.ToTable("BlogTags", "app");

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

            // İlişki: BlogTag -> Blog
            builder.HasOne(bt => bt.Blog)
                   .WithMany(b => b.Tags)
                   .HasForeignKey(bt => bt.BlogId);

            // İlişki: BlogTag -> Tag
            builder.HasOne(bt => bt.Tag)
                   .WithMany(t => t.Blogs)
                   .HasForeignKey(bt => bt.TagId);
        }
    }
}
