using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ICustomerAwardApp : IAppBaseCRUD<CustomerAward, int>
    {
        Task<List<CustomerAward>> GetAllAwardByCustomer(int customerId);
    }
}
