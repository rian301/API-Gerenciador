using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ICustomerPaymentRepository : IRepositoryBaseCRUD<CustomerPayment, int>
    {
        Task<List<CustomerPayment>> GetAllPaymentByCustomer(int customerId);
    }
}
