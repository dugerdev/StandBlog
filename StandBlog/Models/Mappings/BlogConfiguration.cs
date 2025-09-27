using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings;

public class BlogConfiguration
    : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.ToTable("Blogs", "app");

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

        builder.Property(x => x.Title)
               .IsRequired()
               .HasMaxLength(256);

        builder.HasIndex(x => x.Title)
               .IsUnique();

        builder.Property(x => x.Post)
               .IsRequired()
               .HasColumnType("ntext");

        builder.HasOne(b => b.Category)
               .WithMany(c => c.Blogs)
               .HasForeignKey(b => b.CategoryId);
    }
}
