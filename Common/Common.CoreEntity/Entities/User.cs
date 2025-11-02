using Common.CoreEntity.Base;
using Common.CoreEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
