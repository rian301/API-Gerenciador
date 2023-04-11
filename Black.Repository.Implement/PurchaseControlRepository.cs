using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
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
    public class PurchaseControlRepository : RepositoryBaseCRUD<PurchaseControl, int>, IPurchaseControlRepository
    {
        public PurchaseControlRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }
        public Task<int> QuantityPurchaseControls()
        {
            return dbSet.CountAsync();
        }

        public async Task<IQueryable<PurchaseControl>> GetAllPagination(string requestName, string description, DateTime? dateSolicitation, DateTime? datePurchase, DateTime? dateDelivery, PaginationDTO pagination)
        {
            if (dateSolicitation != null)
                dateSolicitation = dateSolicitation.Value.Date;
            if (datePurchase != null)
                datePurchase = datePurchase.Value.Date;
            if (dateDelivery != null)
                dateDelivery = dateDelivery.Value.Date;

            var query = dbSet.AsQueryable();

            if (description != "null" && description != null)
            {
                query = dbSet.Where(x => x.Description.Contains(description));
            }
            if (dateDelivery != null)
            {
                query = dbSet.Where(x => x.DateDelivery.Value.Date == dateDelivery);
            }
            if(description == "null" || description == null && dateDelivery == null)
            {
                query = dbSet.Where(x => x.DateDelivery == null);
            }
            query.Skip(pagination.Page * pagination.Limit);
            query.Take(pagination.Limit).OrderBy(x => x.DateSolicitation);
            return query;
        }
    }
}
