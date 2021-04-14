using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Enums
{
    public enum MISACode
    {
        ISVALID = 100,
        // Thành công
        SUCCESS = 200,

        // Lỗi request từ phía người dùng
        NOTVALID = 400,

        // Không tìm thấy yêu cầu
        NOTFOUND = 404,

        // Xảy ra exception
        EXCEPTION = 600
    }
}
