using NTierApp.Core.Models.Common;

namespace NTierApp.Core.Models
{
    public class Student : AuditableEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public int Age { get; set; }
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }

        public Guid? GroupId { get; set; }
        public Group Group { get; set; } = null!;
    }

}
