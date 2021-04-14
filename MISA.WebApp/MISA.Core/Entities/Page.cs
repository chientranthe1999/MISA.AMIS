using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Core.Entities
{
    public class Page<T>
    {
        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public IEnumerable<T> Data { get; set; }

        /// <summary>
        /// Số lượng bản ghi của 1 page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Tổng số bản ghi của đối tượng T trong database
        /// </summary>
        public long Count { get; set; }
    }
}
