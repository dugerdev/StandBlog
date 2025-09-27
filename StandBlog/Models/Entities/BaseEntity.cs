namespace StandBlog.Models.Entities;

public abstract class BaseEntity
{
    public string Id { get; set; } = string.Empty;
    public bool IsDeleted { get; set; }
    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? ModifiedOn { get; set; }
    public DateTimeOffset? DeletedOn { get; set; }
}
