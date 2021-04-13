using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Hàm tìm nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã khách hàng</param>
        /// <returns>
        /// - Đối tượng nếu tìm thấy
        /// </returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        public bool GetByEmployeeCode(string employeeCode);
    }
}
