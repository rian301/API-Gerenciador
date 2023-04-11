using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class AwardRepository : RepositoryBaseCRUD<Award, int>, IAwardRepository
    {
        public AwardRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        public Task<int> QuantityAwards()
        {
            return dbSet.CountAsync();
        }
    }
}
