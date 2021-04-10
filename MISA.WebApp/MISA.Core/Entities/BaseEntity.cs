using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{

    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class CheckDuplicate : Attribute
    {
    }


    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey : Attribute
    {
    }
    public abstract class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }
    }
}
