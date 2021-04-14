using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WebApp.Controllers
{
    /// <summary>
    /// Api danh muc khach hang
    /// CreatedBy: Chiến Nobi (05/04/2021)
    /// </summary>

    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Declare
        IEmployeeService _employeeService;
        #endregion

        #region Constructor
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion

        #region Method
        [HttpGet("by")]
        public IActionResult GetByEmployeeCode([FromQuery] string code)
        {
            var res = _employeeService.GetByEmployeeCode(code);
            return Ok(res);
        }

        [HttpGet("page")]
        public IEnumerable<Employee> Get([FromQuery] int offset, [FromQuery] int limmit)
        {
            var paging = new { offset = offset, limmit = limmit };
            return  _employeeService.Get(paging);
           
        }
        #endregion

    }
}
