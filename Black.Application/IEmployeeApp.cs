using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IEmployeeApp : IAppBaseCRUD<Employee, int>
    {
        Task<Employee> Create(EmployeeDTO lead);
        Task<Employee> UpdateAsync(EmployeeDTO dto);
        Task<int?> QuantityEmployees();
        Task<Employee> GetByCpfAsync(string cpf);
        Task<bool> ChangeStatus(int customerId, EmployeeStatusEnum status);

    }
}
