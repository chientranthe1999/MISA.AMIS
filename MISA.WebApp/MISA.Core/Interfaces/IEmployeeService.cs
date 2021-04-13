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
        public bool GetByEmployeeCode(string employeeCode);
    }
}
