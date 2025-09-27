using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings;

public class CategoryConfiguration
    : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories", "app");

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

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(256);

        builder.HasIndex(x => x.Name)
               .IsUnique();
    }
}
