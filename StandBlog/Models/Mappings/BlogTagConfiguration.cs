using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings;

public class BlogTagConfiguration
    : IEntityTypeConfiguration<BlogTag>
{
    public void Configure(EntityTypeBuilder<BlogTag> builder)
    {
        builder.ToTable("BlogTags", "app");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
               .HasMaxLength(36);

        builder.Property(x => x.IsDeleted)
               .IsRequired()
               .HasDefaultValue(false);

        builder.Property(x => x.CreatedOn)
               .IsRequired()
               .ValueGeneratedOnAdd();

        builder.HasQueryFilter(x => !x.IsDeleted);

        builder.HasOne(bt => bt.Blog)
               .WithMany(b => b.Tags)
               .HasForeignKey(bt => bt.BlogId);

        builder.HasOne(bt => bt.Tag)
               .WithMany(t => t.Blogs)
               .HasForeignKey(bt => bt.TagId);
    }
}
