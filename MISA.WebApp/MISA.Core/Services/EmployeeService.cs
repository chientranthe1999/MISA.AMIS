﻿using MISA.Core.Entities;
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
       

            _serviceResult.devMsg = String.Empty;

            // Check CustomerCode không được trống
            if (String.IsNullOrEmpty(t.EmployeeCode))
            {
                _serviceResult.devMsg += Resouces.Message.EmptyCustomerCode;
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
                _serviceResult.devMsg += ", " + Resouces.Message.DuplicateCustomerCode;
                isValid = false;
            }
            return isValid;
        }

        public bool GetByEmployeeCode(string customerCode)
        {
            var res = _employeeRepository.GetByEmployeeCode(customerCode);
            return res;
        }

        #endregion
    }
}
