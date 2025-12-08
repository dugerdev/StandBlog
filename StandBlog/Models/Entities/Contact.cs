namespace StandBlog.Models.Entities
{
    public class Contact : BaseEntity
    {
        // Gönderenin adı
        public string Name { get; set; } = string.Empty;

        // Gönderenin e-posta adresi
        public string Email { get; set; } = string.Empty;

        // Mesajın konusu
        public string Subject { get; set; } = string.Empty;

        // Mesaj içeriği
        public string Message { get; set; } = string.Empty;
    }
}
