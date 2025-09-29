namespace StandBlog.Models.Entities
{
    public class Category : BaseEntity
    {
        // Kategori adı
        public string Name { get; set; } = string.Empty;

        // Bu kategoriye ait bloglar
        public ICollection<Blog>? Blogs { get; set; }
    }
}
