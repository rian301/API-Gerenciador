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
    public class MentoredCompanyRepository : RepositoryBaseCRUD<MentoredCompany, int>, IMentoredCompanyRepository
    {
        public MentoredCompanyRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        public Task<List<MentoredCompany>> GetAllCompanyByMentored(int mentoredId)
        {
            return dbSet.Where(x => x.MentoredId == mentoredId)
                .ToListAsync();
        }
    }
}
