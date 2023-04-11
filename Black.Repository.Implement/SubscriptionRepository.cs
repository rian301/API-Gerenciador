using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class SubscriptionRepository : RepositoryBaseCRUD<Subscription, int>, ISubscriptionRepository
    {
        public SubscriptionRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<Subscription> GetByMentoredAsync(int mentoredId)
        {
            return dbSet.Where(w => w.MentoredId.Equals(mentoredId)).FirstOrDefaultAsync();
        }

        public override Task<Subscription> GetByIdAsync(int id)
        {
            return dbSet.Where(w => w.Id == id).Include(i => i.Invoices).FirstOrDefaultAsync();
        }

        public Task<List<Subscription>> GetAllByMentoredAsync(int mentoredId, int? partnerId)
        {
            return dbSet.Where(w => w.MentoredId.Equals(mentoredId) || w.MentoredId.Equals(partnerId))
                .Include(i => i.Invoices)
                .Include(i => i.Product)
                .OrderByDescending(o => o.CreatedAt)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<List<Subscription>> GetAllByDateAsync(DateTime? date)
        {
            if(date != null)
            return dbSet
                        .Where(w => w.Mentored.Status != MentoredStatusEnum.Inactive && w.EndSubscriptionDate <= date.Value.Date)
                        .Include(i => i.Mentored)
                        .Include(i => i.Product)
                        .OrderBy(o => o.EndSubscriptionDate)
                        .AsNoTracking()
                        .ToListAsync();
            else
                return dbSet
                        .Where(w => w.Mentored.Status != MentoredStatusEnum.Inactive && w.Status != SubscriptionStatusEnum.Inactive && w.Status != SubscriptionStatusEnum.Canceled)
                        .Include(i => i.Mentored)
                        .Include(i => i.Product)
                        .OrderBy(o => o.EndSubscriptionDate)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<List<Subscription>> GetAllByProduct(int productId)
        {
            return dbSet.Where(x => x.ProductId == productId).ToListAsync();
        }

    }
}
