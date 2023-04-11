using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
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
    public class DailyPaymentRepository : RepositoryBaseCRUD<DailyPayment, int>, IDailyPaymentRepository
    {
        public DailyPaymentRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        public Task<int> QuantityDailyPayments()
        {
            return dbSet.CountAsync();
        }

        public override Task<List<DailyPayment>> GetAllAsync()
        {
            return dbSet
                .Include(i => i.Provider)
                .Include(i => i.ExpenseCategory)
                .Where(x => x.Deleted == DeletedEnum.No)
                .AsNoTracking()
                .OrderByDescending(o => o.DateSchedulingPayment)
                .ToListAsync();
        }

        public Task<List<DailyPayment>> GetAllPagination(string name, DateTime? date, string provider, string category, PaginationDTO pagination)
        {
            if(date != null)
            date = date.Value.Date;

            if (name != "null" && name != null || provider != "null" && provider != null || category != "null" && category != null || date != null)
                return dbSet
                    .Include(i => i.Provider)
                    .Include(i => i.ExpenseCategory)
                    .Where(x => x.Name.Contains(name) || x.Provider.Name.Contains(provider) || x.ExpenseCategory.Name.Contains(category) || x.DateSchedulingPayment.Value.Date == date && x.Deleted == DeletedEnum.No)
                    .Skip(pagination.Page * pagination.Limit)
                    .Take(pagination.Limit).OrderBy(x => x.Name)
                    .ToListAsync();
            else
                return dbSet
                    .Include(i => i.Provider)
                    .Include(i => i.ExpenseCategory)
                    .Where(x => x.DatePayment == null && x.Deleted == DeletedEnum.No)
                    .Skip(pagination.Page * pagination.Limit)
                    .Take(pagination.Limit)
                    .OrderBy(x => x.Name)
                    .ToListAsync();
        }
    }
}
