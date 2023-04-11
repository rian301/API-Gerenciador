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
    public class CustomerProductRepository : RepositoryBaseCRUD<CustomerProduct, int>, ICustomerProductRepository
    {
        public CustomerProductRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<List<CustomerProduct>> GetAllProductByCustomer(int productId)
        {
            return dbSet.Where(x => x.ProductId == productId)
                        .ToListAsync();
        }

        public Task<List<CustomerProduct>> GetAllCustomerProductByIdCustomer(int customerId)
        {
            return dbSet.Where(x => x.CustomerId == customerId)
                        .ToListAsync();
        }

        //public Task<List<GetProductByCountCustomerQueryResult>> GetProductByCountCustomer()
        //{
        //    var t = (from a in Context.CustomerProduct
        //             join b in Context.Product on a.ProductId equals b.Id into _b
        //             from b in _b.DefaultIfEmpty()
        //             select new GetProductByCountCustomerQueryResult
        //             {
        //                 Id = b.Id,
        //                 Name = b.Name,
        //                 ProductId = a.ProductId,
        //                 QuantityCustomers,
        //                 TimeAccess = B.TimeAccess
        //             })
        //            .ToListAsync();
        //    return null;
        //}
    }
}
