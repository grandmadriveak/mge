using Common.CoreEntity.Base;
using Common.CoreEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CoreEntity.Entities
{
    public class RolePermissionMapping : BaseEntity
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
