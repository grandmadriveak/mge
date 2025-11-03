using Common.CoreEntity.Base;
using Common.CoreEntity.Enums;

namespace Common.CoreEntity.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public string Photo { get; set; }
        public DateTimeOffset DateOfBirth { get; set; }
    }
}
