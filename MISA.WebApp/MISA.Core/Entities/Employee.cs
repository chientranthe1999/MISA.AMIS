using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    /// <summary>
    /// Thông tin Nhân Viên
    /// </summary>
    /// CreatedBy: Chiến Nobi (13/04/2021)
    public class Employee : BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khóa chính: ID của nhân viên kiểu GUID
        /// </summary>
        [PrimaryKey]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [Required]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Họ và tên
        /// </summary>
        [Required]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính (0-Nam, 1-Nữ, 2-Khác)
        /// </summary>
        public int? Gender { get; set; }

        /// <summary>
        /// Phòng ban của nhân viên
        /// </summary>
        public string EmployeeDepartment { get; set; }

        /// <summary>
        /// Mã số CMTND
        /// </summary>
        [Required]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        [Required]
        public string IdentityDate { get; set; }

        /// <summary>
        /// Nơi cấp mã số chứng minh
        /// </summary>
        public string IdentityPlace { get; set; }

        /// <summary>
        /// Vị trí trong công ty (VD: trưởng phòng, ...)
        /// </summary>
        public string EmployeePosition { get; set; }

        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Nơi ở 
        /// </summary>
        public string EmployeeAdress { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string TeleNumber { get; set; }
        #endregion

        public string EmployeeAccountNumber { get; set; }

        public string BankName { get; set; }
    }
}

