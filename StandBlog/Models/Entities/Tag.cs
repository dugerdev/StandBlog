namespace StandBlog.Models.Entities;

public class Tag
    : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public ICollection<BlogTag>? Blogs { get; set; }
}
