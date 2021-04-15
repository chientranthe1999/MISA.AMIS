using MISA.Core.Entities;
using MISA.Core.Interfaces;


namespace MISA.Core.Services
{
    /// <summary>
    /// Service xử lý các nghiệp vụ liên quan tới CustomerGroup
    /// </summary>
    /// CreatedBy: Chiến Nobi(07/04/2021)
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        #region Declare
        IDepartmentRepository _departmentRepository;
        #endregion

        public DepartmentService(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
    }
}
