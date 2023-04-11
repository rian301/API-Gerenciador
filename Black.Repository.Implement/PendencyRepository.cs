using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class PendencyRepository : RepositoryBaseCRUD<Pendency, int>, IPendencyRepository
    {
        public PendencyRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<Pendency> GetByDescriptionAsync(string description)
        {
            return dbSet.Where(w => w.Description.Equals(description.Trim())).FirstOrDefaultAsync();
        }
    }
}
