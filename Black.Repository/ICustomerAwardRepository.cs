using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ICustomerAwardRepository : IRepositoryBaseCRUD<CustomerAward, int>
    {
        Task<List<CustomerAward>> GetAllAwardByCustomer(int customerId);
    }
}
