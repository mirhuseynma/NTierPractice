
namespace NTierApp.Core.Models.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }

    public abstract class AuditableEntity : BaseEntity
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
    
}
