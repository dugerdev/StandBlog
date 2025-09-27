using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StandBlog.Models.Entities;

namespace StandBlog.Models.Mappings;

public class CommentConfiguration
    : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments", "app");

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

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(256);

        builder.Property(x => x.Message)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(c => c.Blog)
               .WithMany(b => b.Comments)
               .HasForeignKey(c => c.BlogId);
    }
}
