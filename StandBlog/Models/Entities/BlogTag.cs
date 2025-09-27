namespace StandBlog.Models.Entities;

public class BlogTag
    : BaseEntity
{
    public string BlogId { get; set; } = string.Empty;
    public string TagId { get; set; } = string.Empty;

    public Blog? Blog { get; set; }
    public Tag? Tag { get; set; }
}
