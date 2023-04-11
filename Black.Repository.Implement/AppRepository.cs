using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class AppRepository : RepositoryBaseCRUD<App, int>, IAppRepository
    {
        public AppRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

    }
}
