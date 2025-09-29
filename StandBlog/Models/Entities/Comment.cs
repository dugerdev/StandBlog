namespace StandBlog.Models.Entities
{
    public class Comment : BaseEntity
    {
        // Yorumun ait olduğu blogun ID'si
        public string BlogId { get; set; } = string.Empty;

        // Yorum yapanın adı
        public string Name { get; set; } = string.Empty;

        // Yorum yapanın e-posta adresi
        public string Email { get; set; } = string.Empty;

        // Yorum içeriği
        public string Message { get; set; } = string.Empty;

        // İlişkili blog
        public Blog? Blog { get; set; }
    }
}
