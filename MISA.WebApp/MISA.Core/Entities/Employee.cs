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
        /// Mã Phòng ban của nhân viên
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Tên phòng ban của nhân viên
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mã số CMTND
        /// </summary>
        [Required]
        public string IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        [Required]
        public DateTime IdentityDate { get; set; }

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
        public string Address { get; set; }

        /// <summary> 
        /// Số điện thoại di động
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string TelephoneNumber { get; set; }
        #endregion

        /// <summary>
        /// Tên của nhóm khách hàng
        /// </summary>
        public string BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string BankName { get; set; }

        /// <summary>
        /// Tên chi nhánh 
        /// </summary>
        public string BankBranchName { get; set; }

        /// <summary>
        /// Trạng thái tài khoản: 0-Ngưng sử dụng, 1-Đang sử dụng
        /// </summary>
        public int? AccountState { get; set; }

        /// <summary>
        /// Tỉnh thành của ngân hàng
        /// </summary>
        public string BankProvinceName { get; set; }

    }
}

