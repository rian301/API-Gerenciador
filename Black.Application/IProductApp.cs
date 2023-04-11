using Black.Application.Base;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IProductApp : IAppBaseCRUD<Product, int>
    {
        Task<int> QuantityCustomersInProduct(int productId);
        Task<int> QuantityProducts();
        //Task<List<GetProductByCountCustomerQueryResult>> GetProductByCountCustomer();
    }
}
