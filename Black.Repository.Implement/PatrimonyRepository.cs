using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class PatrimonyRepository : RepositoryBaseCRUD<Patrimony, int>, IPatrimonyRepository
    {
        public PatrimonyRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public override Task<List<Patrimony>> GetAllAsync()
        {
            return dbSet.Include(i => i.AssetsCategory).Include(i => i.Provider).ToListAsync();
        }
        public Task<int> QuantityPatrimonys()
        {
            return dbSet.CountAsync();
        }
    }
}
