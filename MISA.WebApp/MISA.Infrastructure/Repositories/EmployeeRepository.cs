using Dapper;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// CreatedBy: Chiến Nobi (05/04/2021)
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public bool GetByEmployeeCode(string employeeCode)
        {
            var sqlQuery = $"Select EmployeeCode from Employee Where EmployeeCode = \"{employeeCode}\"";

            var res = _dbConnection.Query<Employee>(sqlQuery, commandType: CommandType.Text).FirstOrDefault();

            if (res != null) return true;

            else return false;
        }

        public IEnumerable<Employee> Get(Object paging)
        {
            var res = _dbConnection.Query<Employee>($"Proc_Get{_tableName}", paging, commandType: CommandType.StoredProcedure);
            return res;
        }
    }
}
