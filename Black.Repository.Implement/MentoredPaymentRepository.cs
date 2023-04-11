using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class MentoredPaymentRepository : RepositoryBaseCRUD<MentoredPayment, int>, IMentoredPaymentRepository
    {
        public MentoredPaymentRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<List<MentoredPayment>> GetAllByMentoredIdAsync(int mentoredId)
        {
            return dbSet
                .Include(i => i.Mentored)
                .Include(i => i.MentoredCompany)
                .Where(w => w.MentoredId.Equals(mentoredId))
                .ToListAsync();
        }
    }
}
