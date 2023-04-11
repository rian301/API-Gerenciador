using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ICustomerLaunchApp : IAppBaseCRUD<CustomerLaunch, int>
    {
        Task<List<CustomerLaunch>> GetAllLaunchByCustomer(int customerId);
    }
}
