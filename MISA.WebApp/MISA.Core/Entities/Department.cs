using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Đối tượng Phòng ban nhân viên
    /// </summary>
    /// CreatedBy: Chiến Nobi (13/04/2021)
    public class Department : BaseEntity
    {
        /// <summary>
        /// ID của phòng ban 
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban nhân viên
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả đơn vị
        /// </summary>
        public string Description { get; set; }

        
    }
}
