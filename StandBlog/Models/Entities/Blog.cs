namespace StandBlog.Models.Entities;

public class Blog
    : BaseEntity
{
    public string CategoryId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Post { get; set; } = string.Empty;

    public Category? Category { get; set; }
    public ICollection<Comment>? Comments { get; set; }
    public ICollection<BlogTag>? Tags { get; set; }
}
