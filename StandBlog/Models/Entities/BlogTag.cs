namespace StandBlog.Models.Entities
{
    public class BlogTag : BaseEntity
    {
        // İlişkili blog ve tag kimlikleri
        public string BlogId { get; set; } = string.Empty;
        public string TagId { get; set; } = string.Empty;

        // Navigation properties
        public Blog? Blog { get; set; }
        public Tag? Tag { get; set; }
    }
}
