using MISA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Interfaces
{
    public interface IEmployeeService  : IBaseService<Employee>
    {
        /// <summary>
        /// Lấy nhân viên bằng mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>Đối tượng nhân viên hoặc null</returns>
        /// CreatedBy: Chiến Nobi (14/4/2021)
        public bool GetByEmployeeCode(string employeeCode);

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
