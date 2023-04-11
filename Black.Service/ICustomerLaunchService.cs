using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ICustomerLaunchService : IServiceBaseCRUD<CustomerLaunch, int>
    {
        Task<List<CustomerLaunch>> GetAllLaunchByCustomer(int customerId);
    }
}
