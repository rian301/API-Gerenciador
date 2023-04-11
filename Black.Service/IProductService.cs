using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IProductService : IServiceBaseCRUD<Product, int>
    {
        Task<int> QuantityProducts();
        //Task<List<GetProductByCountCustomerQueryResult>> GetProductByCountCustomer();
    }
}
