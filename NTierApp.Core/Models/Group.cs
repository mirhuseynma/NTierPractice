
using NTierApp.Core.Models.Common;

namespace NTierApp.Core.Models
{
    public class Group : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int StudentCount { get; set; }

        public List<Student> Students { get; set; } = null!;

    }
}
