using MISA.Core.Entities;
using MISA.Core.Interfaces;


namespace MISA.WebApp.Controllers
{
    /// <summary>
    /// API Danh mục Vị trí khách hàng
    /// </summary>
    /// CretedBy: Chiến Nobi (07/04/2021)
    public class DepartmentController : BaseEntityController<Department>
    {
        #region Declare
        IDepartmentService _departmentService;
        #endregion

        #region Constructor
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
        #endregion
    }
}
