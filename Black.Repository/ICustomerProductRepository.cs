using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ICustomerProductRepository : IRepositoryBaseCRUD<CustomerProduct, int>
    {
        Task<List<CustomerProduct>> GetAllProductByCustomer(int customerId);
        Task<List<CustomerProduct>> GetAllCustomerProductByIdCustomer(int customerId);
    }
}
