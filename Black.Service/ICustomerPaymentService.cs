using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ICustomerPaymentService : IServiceBaseCRUD<CustomerPayment, int>
    {
        Task<List<CustomerPayment>> GetAllPaymentByCustomer(int customerId);
    }
}
