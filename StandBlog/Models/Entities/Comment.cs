namespace StandBlog.Models.Entities;

public class Comment
    : BaseEntity
{
    public string BlogId { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public Blog? Blog { get; set; }
}
