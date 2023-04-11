using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class ProductService : ServiceBaseCRUD<Product, int>, IProductService
    {
        #region Properties

        private readonly IProductRepository _repository;

        #endregion

        public ProductService(IProductRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<int> QuantityProducts() => _repository.QuantityProducts();
        //public Task<List<GetProductByCountCustomerQueryResult>> GetProductByCountCustomer() => _repository.GetProductByCountCustomer();
    }
}
