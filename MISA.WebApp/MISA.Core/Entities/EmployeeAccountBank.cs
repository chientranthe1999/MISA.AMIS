using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin Tài Khoản Ngân Hàng
    /// </summary>
    /// CreatedBy: Chiến Nobi (13/04/2021)
    public class EmployeeAccountBank : BaseEntity
    {
        #region Properties
        /// <summary>
        /// ID số tài khoản nhân viên
        /// </summary>
        public Guid EmployeeAccountId { get; set; }

        /// <summary>
        /// Tên của nhóm khách hàng
        /// </summary>
        public string EmployeeAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh
        /// </summary>
        public string BranchName { get; set; }

        /// <summary>
        /// Tỉnh Tp của ngân hàng
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// ID của nhân viên có số tài khoản này
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Trạng thái tài khoản: 0-Ngưng sử dụng, 1-Đang sử dụng
        /// </summary>
        public string StateAccount { get; set; }
        #endregion
    }
}
