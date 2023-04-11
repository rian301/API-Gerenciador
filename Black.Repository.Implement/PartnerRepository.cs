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
    public class PartnerRepository : RepositoryBaseCRUD<Partner, int>, IPartnerRepository
    {
        public PartnerRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        public Task<int> QuantityPartners()
        {
            return dbSet.CountAsync();
        }

        public Task<List<Partner>> GetByMentoredId(int mentoredId)
        {
            return dbSet.Where(x => x.MentoredId == mentoredId).Include(i => i.Mentored).ToListAsync();
        }

        public Task<Partner> GetByMentoredPartnerId(int mentoredId)
        {
            return dbSet.Where(x => x.MentoredPartnerId == mentoredId).Include(i => i.Mentored).FirstOrDefaultAsync();
        }

        public Task<Partner> GetByMentoredAndPartnerId(int partnerId, int mentoredId)
        {
            return dbSet.Where(x => x.MentoredPartnerId == partnerId && x.MentoredId == mentoredId).Include(i => i.Mentored).FirstOrDefaultAsync();
        }
    }
}
