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
        public Employee GetByEmployeeCode(string employeeCode)
        {
            var sqlQuery = $"Select EmployeeCode from Employee Where EmployeeCode = \"{employeeCode}\"";

            var res = _dbConnection.Query<Employee>(sqlQuery, commandType: CommandType.Text).FirstOrDefault();

            return res;
        }

        public IEnumerable<Employee> Get(Object paging)
        {
            var res = _dbConnection.Query<Employee>($"Proc_Get{_tableName}", paging, commandType: CommandType.StoredProcedure);
            return res;
        }

        public Employee GetByEmployeeCode(string employeeCode, Guid employeeId)
        {
            var sql = $"Select * from Employee Where EmployeeCode = \"{employeeCode}\" AND EmployeeId <> \"{employeeId}\"";
            var res = _dbConnection.Query<Employee>(sql, commandType: CommandType.Text).FirstOrDefault();
            return res;
        }

        public int GetCountEmployee()
        {
            throw new NotImplementedException();
        }
    }
}
