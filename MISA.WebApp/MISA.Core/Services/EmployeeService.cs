using MISA.Core.Entities;
using MISA.Core.Enums;
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
        public override bool ValidateAdd(Employee t)
        {
            bool isValid = true;
            var isDuplicate = _employeeRepository.GetByEmployeeCode(t.EmployeeCode);

            // Check EmployeeCode không được trống
            if (String.IsNullOrEmpty(t.EmployeeCode))
            {
                _serviceResult.DevMsg.Add(Resouces.Message.EmptyCustomerCode);
                isValid = false;
            }

            // Check Tên không được trống
            if (String.IsNullOrEmpty(t.EmployeeName))
            {
                _serviceResult.DevMsg.Add(Resouces.Message.EmptyCustomerName);
                isValid = false;
            }

            // Check trùng mã
            if (isDuplicate != null)
            {
                _serviceResult.DevMsg.Add(Resouces.Message.DuplicateCustomerCode);
                isValid = false;
            }
            return isValid;
        }

        public override ServiceResult Update(Employee t, Guid id)
        {
            // validate dữ liệu
            var isValid = ValidateUpdate(t, id);

            if (isValid == true)
            {
                t.EmployeeId = id;
                _serviceResult.DevMsg.Add(Resouces.Message.AddSuccess);
                _serviceResult.UserMsg = Resouces.Message.AddSuccess;
                _serviceResult.Data = _employeeRepository.Update(t, id);
                _serviceResult.MisaCode = MISACode.ISVALID;
            }

            else
            {
                _serviceResult.MisaCode = MISACode.NOTVALID;
            }

            return _serviceResult;
        }


        public override bool ValidateUpdate(Employee t, Guid id)
        {
            bool isValid = true;
            var isDuplicate = _employeeRepository.GetByEmployeeCode(t.EmployeeCode, id);

            // ID không được để trống
            if (id == Guid.Empty)
            {
                _serviceResult.DevMsg.Add(Resouces.Message.EmptyID);
                _serviceResult.UserMsg = Resouces.Message.UpdateError;
                return false;
            }

            // Check EmployeeCode không được trống
            if (String.IsNullOrEmpty(t.EmployeeCode))
            {
                _serviceResult.DevMsg.Add(Resouces.Message.EmptyCustomerCode);
                isValid = false;
            }

            // Check trùng mã EmployeeCode
            if (isDuplicate != null)
            {
                isValid = false;
            }
            return isValid;
            
        }

        // Check trùng mã Code khi Thêm
        public bool CheckAddEmployeeCode(string employeeCode)
        {
            var res = _employeeRepository.GetByEmployeeCode(employeeCode);
            if (res == null)
            {
                return false;
            }
            else return true;
        }

        // Check trùng mã Code khi update
        public bool CheckUpdateEmployeeCode(string employeeCode, Guid id)
        {
            var res = _employeeRepository.GetByEmployeeCode(employeeCode, id);
            if (res == null)
            {
                return false;
            }
            else return true;
        }


        public IEnumerable<Employee> Get(object paging)
        {
            return _employeeRepository.Get(paging);
        }

        public IEnumerable<Employee> Search(string value)
        {
            return _employeeRepository.Search(value);

        }

        public string GetMaxEmployeeCode()
        {
            return _employeeRepository.GetMaxEmployeeCode();
        }

        #endregion
    }
}
