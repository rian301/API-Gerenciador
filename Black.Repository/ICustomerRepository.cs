using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ICustomerRepository : IRepositoryBaseCRUD<Customer, int>
    {
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByDocumentAsync(string cpf);
        Task<Customer> GetByUserIdAsync(int userId);
        Task<int> QuantityCustomers();
        Task<int> QuantityCustomersInProduct(int productId);
        Task<bool> CheckEmailInUse(string email, int? ignoreId);
        Task<bool> CheckDocumentInUse(string cpf, int? ignoreId);
        Task<List<Customer>> GetAllPagination(string name, string email, PaginationDTO pagination);
        Task<List<Customer>> GetByNameAsync(string name);
    }
}
