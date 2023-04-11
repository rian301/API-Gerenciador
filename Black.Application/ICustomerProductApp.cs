using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ICustomerProductApp : IAppBaseCRUD<CustomerProduct, int>
    {
        Task<List<CustomerProduct>> GetAllProductByCustomer(int customerId);
        Task<List<CustomerProduct>> GetAllCustomerProductByIdCustomer(int customerId);
    }
}
