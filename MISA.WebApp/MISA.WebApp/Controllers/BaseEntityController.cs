﻿using Microsoft.AspNetCore.Mvc;
using MISA.Core.Enums;
using MISA.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.WebApp.Controllers
{
    /// <summary>
    /// Base Controller 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// CreatedBy: Chiến Nobi (07/04/2021)
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class BaseEntityController<T> : ControllerBase
    {
        #region Declare
        IBaseService<T> _baseService;
        #endregion

        #region Constructor
        public BaseEntityController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method

        /// <summary>
        /// Hàm lấy toàn bộ danh sách đối tượng
        /// </summary>
        /// <returns>Danh sách đối tượng</returns>
        /// CreatedBy: Chiến Nobi (09/04/2021)
        [HttpGet]
        public IEnumerable<T> Get()
        {
            return _baseService.Get();
        }

        /// <summary>
        /// Hàm đối tượng theo ID
        /// </summary>
        /// <returns>Đối tượng tìm thấy hoặc null nếu ko tìm thấy</returns>
        /// CreatedBy: Chiến Nobi (09/04/2021)
        [HttpGet("{id}")]
        public T Get(Guid id)
        {
            return _baseService.GetById(id);
        }

        /// <summary>
        /// Thêm mới dữ liệu
        /// </summary>
        /// <param name="t">Đối tượng thêm mới</param>
        /// <returns>
        /// - Mã HTTP code 200: nếu thêm thành công
        /// - Mã HTTP code 400: Bad Request nếu có lỗi từ client 
        /// </returns>
        [HttpPost]
        public IActionResult Add([FromBody] T t)
        {
            var res = _baseService.Add(t);
            if (res.MisaCode == MISACode.ISVALID) return Created("", res);
            else return BadRequest(res);
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //}

        /// <summary>
        /// Xóa bản ghi theo ID
        /// </summary>
        /// <param name="id">ID của đối tượng cần xóa</param>
        /// <returns>Mã code 200 nếu xóa thành công hoặc 204 nếu ko tìm thấy ID cần xóa</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var res = _baseService.Delete(id);
            if (res.MisaCode == MISACode.SUCCESS) return Ok(res);
            else return StatusCode(204, res);
        }

        #endregion
    }
}
