using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class SentRepository : RepositoryBaseCRUD<Sent, int>, ISentRepository
    {
        public SentRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        public Task<int> QuantitySents()
        {
            return dbSet.CountAsync();
        }

        public override async Task<List<Sent>> GetAllAsync()
        {
            return await dbSet
                .Include(x => x.Customer)
                .Include(x => x.Mentored)
                .Include(x => x.Award)
                .ToListAsync();
        }

        public async Task<IQueryable<Sent>> GetAllPagination(QuerySentDTO filter, PaginationDTO pagination)
        {
            if (filter.Customer == "null")
                filter.Customer = null;
            if (filter.Mentored == "null")
                filter.Mentored = null;
            if (filter.Award == "null")
                filter.Award = null;

            var query = dbSet
                .Include(x => x.Customer)
                .Include(x => x.Mentored)
                .Include(x => x.Award)
                .AsQueryable();

            if (filter.Customer != null && filter.Customer != "null" && filter.Customer.Any())
            {
                query = query.Where(x => x.Customer.Name.ToLower().Contains(filter.Customer.ToLower()));
            }
            if (filter.Mentored != null && filter.Mentored != "null" && filter.Mentored.Any())
            {
                query = query.Where(x => x.Mentored.Name.ToLower().Contains(filter.Mentored.ToLower()));
            }
            if (filter.Award != null && filter.Award != "null" && filter.Award.Any())
            {
                query = query.Where(x => x.Award.Name.ToLower().Contains(filter.Award.ToLower()));
            }
            if (filter.Status != null)
            {
                query = query.Where(x => x.Status == filter.Status);
            }
            if (
                filter.Customer == null &&
                filter.Mentored == null &&
                filter.Award == null &&
                filter.Status == null)
            {
                query = dbSet
                    .Include(x => x.Customer)
                    .Include(x => x.Mentored)
                    .Include(x => x.Award)
                    .Where(x => x.Status == SentStatusEnum.InProgress)
                    .Skip(pagination.Page * pagination.Limit)
                    .Take(pagination.Limit)
                    .OrderBy(x => x.DateRequest)
                    .AsQueryable();
            }

            query.Skip(pagination.Page * pagination.Limit);
            query.Take(pagination.Limit).OrderBy(x => x.DateRequest);
            return query;
        }

        public Task<bool> GetByAwardAsync(int awardId, int customerId, int? ignoreId)
        {
            return dbSet
                .Where(w => w.CustomerId == customerId && w.AwardId.Equals(awardId))
                .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                .AnyAsync();
        }

        public Task<bool> GetMentoredByAwardAsync(int awardId, int mentoredId, int? ignoreId)
        {
            return dbSet
                .Where(w => w.MentoredId == mentoredId && w.AwardId.Equals(awardId))
                .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                .AnyAsync();
        }
    }
}
