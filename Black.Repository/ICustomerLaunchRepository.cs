using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ICustomerLaunchRepository : IRepositoryBaseCRUD<CustomerLaunch, int>
    {
        Task<List<CustomerLaunch>> GetAllLaunchByCustomer(int customerId);
    }
}
