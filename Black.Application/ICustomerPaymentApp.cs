using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ICustomerPaymentApp : IAppBaseCRUD<CustomerPayment, int>
    {
        Task<List<CustomerPayment>> GetAllPaymentByCustomer(int customerId);
    }
}
