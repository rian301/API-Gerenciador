using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ICustomerProductService : IServiceBaseCRUD<CustomerProduct, int>
    {
        Task<List<CustomerProduct>> GetAllProductByCustomer(int customerId);
        Task<List<CustomerProduct>> GetAllCustomerProductByIdCustomer(int customerId);
    }
}
