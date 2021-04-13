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
    public class EmployeeDepartment : BaseEntity
    {
        /// <summary>
        /// ID của phòng ban 
        /// </summary>
        public int EmployeeDepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban nhân viên
        /// </summary>
        public string EmployeeDepartmentName { get; set; }

        /// <summary>
        /// Mô tả đơn vị
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Trách nhiệm của đơn vị
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Quyền lợi của đơn vị
        /// </summary>
        public string Profit { get; set; }
    }
}
