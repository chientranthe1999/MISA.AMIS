using MISA.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class ServiceResult
    {
        #region Declare
        /// <summary>
        /// Thông báo cho dev
        /// </summary>
        public string DevMsg { get; set; } = "";

        /// <summary>
        /// Thông báo cho người dùng
        /// </summary>
        public string UserMsg { get; set; } = "";

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public MISACode MisaCode { get; set; } = MISACode.SUCCESS;

        /// <summary>
        /// Dữ liệu trả về nếu có
        /// </summary>
        public object Data { get; set; } = new { };

        /// <summary>
        /// Log lỗi trên hệ thống
        /// </summary>
        public string TraceId { get; set; } = "";
        #endregion
    }
}
