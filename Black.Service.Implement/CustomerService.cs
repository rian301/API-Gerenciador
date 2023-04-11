using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.CrossCutting.Common.String;
using Black.Repository;
using Black.Service.Implement.Base;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class CustomerService : ServiceBaseCRUD<Customer, int>, ICustomerService
    {
        #region Properties

        private readonly ICustomerRepository _customerRepository;

        #endregion

        public CustomerService(ICustomerRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _customerRepository = repository;
        }

        public Task<Customer> GetByEmailAsync(string email) => _customerRepository.GetByEmailAsync(email);
        public Task<Customer> GetByDocumentAsync(string cpf) => _customerRepository.GetByDocumentAsync(cpf.RemoverCaracterMascara());
        public Task<Customer> GetByUserIdAsync(int userId) => _customerRepository.GetByUserIdAsync(userId);
        public Task<int> QuantityCustomers() => _customerRepository.QuantityCustomers();
        public Task<int> QuantityCustomersInProduct(int productId) => _customerRepository.QuantityCustomersInProduct(productId);
        public Task<bool> CheckEmailInUse(string email, int? ignoreId) => _customerRepository.CheckEmailInUse(email, ignoreId);
        public Task<bool> CheckDocumentInUse(string cpf, int? ignoreId) => _customerRepository.CheckDocumentInUse(cpf, ignoreId);
        public Task<List<Customer>> GetAllPagination(string name, string email, PaginationDTO pagination) => _customerRepository.GetAllPagination(name, email, pagination);
        public Task<List<Customer>> GetByNameAsync(string name) => _customerRepository.GetByNameAsync(name);
    }
}
