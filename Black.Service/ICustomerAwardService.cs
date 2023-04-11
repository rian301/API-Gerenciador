using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ICustomerAwardService : IServiceBaseCRUD<CustomerAward, int>
    {
        Task<List<CustomerAward>> GetAllAwardByCustomer(int customerId);
    }
}
