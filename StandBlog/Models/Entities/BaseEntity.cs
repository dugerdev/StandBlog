namespace StandBlog.Models.Entities
{
    public abstract class BaseEntity
    {
        // Kimlik
        public string Id { get; set; } = string.Empty;

        // Silinme durumu
        public bool IsDeleted { get; set; }

        // Zaman damgaları
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? ModifiedOn { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
