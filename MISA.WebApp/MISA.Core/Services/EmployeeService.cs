using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Services
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        #region Declare
        IEmployeeRepository _employeeRepository;
        #endregion

        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        #endregion

        #region Method
        public override bool Validate(Employee t)
        {
            
            bool isValid = true;
            var isDuplicate = _employeeRepository.GetByEmployeeCode(t.EmployeeCode);
       

            _serviceResult.DevMsg = String.Empty;

            // Check CustomerCode không được trống
            if (String.IsNullOrEmpty(t.EmployeeCode))
            {
                _serviceResult.DevMsg += Resouces.Message.EmptyCustomerCode;
                isValid = false;
            }

            //// Check xem trường CustomerGroupId không được trống
            //if (String.IsNullOrEmpty(customerGroupId))
            //{
            //    _serviceResult.devMsg += ", " + Resouces.Message.EmptyCustomerGroupId;
            //    isValid = false;
            //}

            // Check trùng mã
            if (isDuplicate)
            {
                _serviceResult.DevMsg += ", " + Resouces.Message.DuplicateCustomerCode;
                isValid = false;
            }
            return isValid;
        }

        public bool GetByEmployeeCode(string customerCode)
        {
            var res = _employeeRepository.GetByEmployeeCode(customerCode);
            return res;
        }

        public IEnumerable<Employee> Get(object paging)
        {
            return _employeeRepository.Get(paging);
        }


        #endregion
    }
}
