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
        /// - True nếu tìm thấy, false nếu ko tìm thấy
        /// </returns>
        /// CreatedBy: Chiến Nobi (05/04/2021)
        public Employee GetByEmployeeCode(string employeeCode);

        /// <summary>
        /// Hàm tìm nhân viên theo mã nhân viên và ID
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <param name="employeeId">ID nhân viên</param>
        /// <returns></returns>
        public Employee GetByEmployeeCode(string employeeCode, Guid employeeId);

        /// <summary>
        /// Trả về tổng số bản ghi của 1 bảng
        /// </summary>
        /// <returns></returns>
        public int GetCountEmployee();

        /// <summary>
        /// Trả về dữ liệu thuộc 1 khoảng nào đó
        /// </summary>
        /// <param name="paging">
        /// - Đối tượng có key: offset, limit
        /// - offset: vị trí bắt đầu lấy dữ liệu
        /// - limit: Số lượng bản ghi cần lấy
        /// </param>
        /// <returns>Danh sách bản ghi </returns>
        /// CreatedBy: Chiến Nobi (14/4/2021)
        public IEnumerable<Employee> Get(Object paging);

        
    }
}
