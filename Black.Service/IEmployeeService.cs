using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IEmployeeService : IServiceBaseCRUD<Employee, int>
    {
        Task<Employee> GetByEmailAsync(string email);
        Task<Employee> GetByCPFAsync(string cpf);
        Task<Employee> GetByCNPJAsync(string cnpj);
        Task<Employee> GetByUserIdAsync(int userId);
        Task<int> QuantityEmployees();
        Task<bool> CheckEmailInUse(string email, int? ignoreId);
        Task<bool> CheckCNPJInUse(string cnpj, int? ignoreId);
        Task<bool> CheckCPFInUse(string cpf, int? ignoreId);
    }
}
