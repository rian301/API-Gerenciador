using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class ProductApp : AppBaseCRUD<Product, int>, IProductApp
    {
        #region Properties
        private readonly IProductService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructors
        public ProductApp(IProductService service, ICustomerService customerService, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
            _customerService = customerService;
        }
        #endregion

        public Task<int> QuantityCustomersInProduct(int productId) => _customerService.QuantityCustomersInProduct(productId);

        //public override async Task<IEnumerable<Product>> GetAllAsync()
        //{
        //    return await _service.GetAllAsync();
        //}
        public Task<int> QuantityProducts() => _service.QuantityProducts();
        //public Task<List<GetProductByCountCustomerQueryResult>> GetProductByCountCustomer() => _service.GetProductByCountCustomer();
    }
}
