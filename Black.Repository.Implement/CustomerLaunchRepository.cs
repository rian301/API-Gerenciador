using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class CustomerLaunchRepository : RepositoryBaseCRUD<CustomerLaunch, int>, ICustomerLaunchRepository
    {
        public CustomerLaunchRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<List<CustomerLaunch>> GetAllLaunchByCustomer(int customerId)
        {
            return dbSet.Where(x => x.CustomerId == customerId)
                .ToListAsync();
        }
    }
}
