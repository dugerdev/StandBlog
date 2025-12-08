namespace StandBlog.Models.Entities
{
    public class Tag : BaseEntity
    {
        // Etiketin adı
        public string Name { get; set; } = string.Empty;

        // Bu etikete ait blog ilişkileri
        public ICollection<BlogTag>? Blogs { get; set; }
    }
}
