using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.CoreEntity.Base
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
    }

    public class ExtendEntity : BaseEntity
    {
        public Guid CreatedById { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Guid ModifiedById { get; set; }
        public DateTimeOffset ModifiedTime { get; set; }
    }
}
