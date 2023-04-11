using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class PaymentMethodRepository : RepositoryBaseCRUD<PaymentMethod, int>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<PaymentMethod> GetByDescriptionAsync(string description)
        {
            return dbSet.Where(w => w.Description.Equals(description)).FirstOrDefaultAsync();
        }
    }
}
