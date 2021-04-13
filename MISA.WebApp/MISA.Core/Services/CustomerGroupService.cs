using MISA.Core.Entities;
using MISA.Core.Interfaces;


namespace MISA.Core.Services
{
    /// <summary>
    /// Service xử lý các nghiệp vụ liên quan tới CustomerGroup
    /// </summary>
    /// CreatedBy: Chiến Nobi (07/04/2021)
    public class CustomerGroupService : BaseService<EmployeeAccountBank>, ICustomerGroupService
    {
        #region Declare
        IEmployeeAccountBankRepository _customerGroupRepository;
        #endregion

        public CustomerGroupService(IEmployeeAccountBankRepository customerGroupRepository) : base(customerGroupRepository)
        {
            _customerGroupRepository = customerGroupRepository;
        }
    }
}
