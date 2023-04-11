using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ICustomerService : IServiceBaseCRUD<Customer, int>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByDocumentAsync(string cpf);
        Task<Customer> GetByUserIdAsync(int userId);
        Task<int> QuantityCustomers();
        Task<bool> CheckEmailInUse(string email, int? ignoreId);
        Task<bool> CheckDocumentInUse(string cpf, int? ignoreId);
        Task<int> QuantityCustomersInProduct(int productId);
        public Task<List<Customer>> GetAllPagination(string name, string email, PaginationDTO pagination);
        Task<List<Customer>> GetByNameAsync(string name);
    }
}
