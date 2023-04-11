using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ICustomerApp : IAppBaseCRUD<Customer, int>
    {
        Task<Customer> Create(CustomerDTO lead);
        Task<Customer> UpdateAsync(CustomerUpdateDTO dto);
        Task<int?> QuantityCustomers();
        Task<Customer> GetByCpfAsync(string cpf);
        Task<int?> QuantityCustomersInProduct();
        Task<bool> ImportExel(MemoryStream stream);
        Task<bool> ChangeStatus(int customerId, CustomerStatusEnum status);
        Task<List<Customer>> GetAllPagination(QueryCustomerDTO query);
        Task<List<Customer>> GetByNameAsync(string name);
    }
}
