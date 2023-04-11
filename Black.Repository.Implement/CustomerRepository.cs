using Microsoft.EntityFrameworkCore;
using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Black.Domain.DTO;

namespace Black.Repository.Implement
{
    public class CustomerRepository : RepositoryBaseCRUD<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<List<Customer>> GetAllPagination(string name, string email, PaginationDTO pagination)
        {
            if (name != "null" && name != null || email != "null" && email != null)
                return dbSet
                    .Where(x => x.Name.Contains(name) || 
                    x.Email.Contains(email))
                    .Skip(pagination.Page * pagination.Limit)
                    .Take(pagination.Limit)
                    .OrderBy(x => x.Name)
                    .ToListAsync();
            else
                return dbSet.Skip(pagination.Page * pagination.Limit).Take(pagination.Limit).OrderBy(x => x.Name).ToListAsync();
        }

        public Task<Customer> GetByEmailAsync(string email)
        {
            return dbSet.Where(w => w.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public Task<List<Customer>> GetByNameAsync(string name)
        {
            return dbSet.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public Task<Customer> GetByDocumentAsync(string cpf)
        {
            return dbSet.Where(w => w.Document.Equals(cpf)).FirstOrDefaultAsync();
        }

        public override Task<List<Customer>> GetAllAsync()
        {
            return dbSet.AsNoTracking().OrderBy(o => o.Name).ToListAsync();
        }

        public Task<Customer> GetByUserIdAsync(int userId)
        {
            return dbSet.Where(w => w.UserId.Equals(userId)).FirstOrDefaultAsync();
        }

        public override Task<Customer> GetByIdAsync(int id)
        {
            return dbSet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task<int> QuantityCustomers()
        {
            return dbSet.CountAsync();
        }

        public Task<int> QuantityCustomersInProduct(int productId)
        {
            return dbSet.Where(x => x.ProductId == productId).CountAsync();
        }

        public Task<bool> CheckEmailInUse(string email, int? ignoreId)
        {
            return dbSet.Where(w => w.Email == email)
                        .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                        .AnyAsync();
        }

        public Task<bool> CheckDocumentInUse(string document, int? ignoreId)
        {
            return dbSet.Where(w => w.Document == document)
                        .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                        .AnyAsync();
        }
    }
}
