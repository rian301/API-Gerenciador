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
    public class InvoiceRepository : RepositoryBaseCRUD<Invoice, int>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<Invoice> GetLastInvoiceBySubscriptionAsync(int subscriptionId)
        {
            return dbSet.Where(w => w.SubscriptionId.Equals(subscriptionId))
                        .OrderByDescending(o => o.CreatedAt)
                        .FirstOrDefaultAsync();
        }

        public override Task<Invoice> GetByIdAsync(int id)
        {
            return dbSet.Include(i => i.Subscription).ThenInclude(i => i.Mentored)
                        .Include(i => i.Subscription.Product)
                        .Include(i => i.Mentored)
                        .Where(w => w.Id == id)
                        .FirstOrDefaultAsync();

        }

        public Task<List<Invoice>> GetAllPendingInvoiceToPaymentAsync()
        {
            return dbSet.Where(w => w.NextAttempt.HasValue && w.NextAttempt.Value.Date == DateTime.UtcNow.AddHours(-3).Date) // Tentativa de pagamento hoje
                        .Where(w => w.Status == InvoiceStatusEnum.Pending) // Ag. pagamento
                        .OrderBy(o => o.CreatedAt)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<List<Invoice>> GetAllByIdSubscriptionAsync(int subscriptionId)
        {
            return dbSet.Where(w => w.SubscriptionId == subscriptionId)
                        .OrderBy(o => o.CreatedAt)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<List<Invoice>> GetByPeriod(DateTime dateInit, DateTime dateEnd)
        {
            return dbSet
                        .Include(i => i.Mentored)
                        .Include(i => i.Subscription)
                        .Where(x => x.ExpirationDate >= dateInit && x.ExpirationDate <= dateEnd)
                        .OrderBy(o => o.ExpirationDate)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<List<Invoice>> GetByPeriodPaid(DateTime dateInit, DateTime dateEnd)
        {
            return dbSet
                        .Include(i => i.Mentored)
                        .Include(i => i.Subscription)
                        .Where(x => x.PaidDate >= dateInit && x.PaidDate <= dateEnd)
                        .OrderBy(o => o.PaidDate)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<List<Invoice>> GetAllPendingBySubscription(int subscriptionId)
        {
            return dbSet.Where(x => x.SubscriptionId == subscriptionId && x.Status == InvoiceStatusEnum.Pending).ToListAsync();
        }

        public Task<List<Invoice>> GetAllWithOverdueInvoice()
        {
            return dbSet.Where(w => w.Status == InvoiceStatusEnum.Pending && w.ExpirationDate <= DateTime.Now.Date).ToListAsync();
        }
    }
}
