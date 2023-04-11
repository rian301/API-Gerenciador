using Microsoft.EntityFrameworkCore;
using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class EmployeeRepository : RepositoryBaseCRUD<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<Employee> GetByEmailAsync(string email)
        {
            return dbSet.Where(w => w.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public Task<Employee> GetByCPFAsync(string cpf)
        {
            return dbSet.Where(w => w.CPF.Equals(cpf)).FirstOrDefaultAsync();
        }

        public Task<Employee> GetByCNPJAsync(string cnpj)
        {
            return dbSet.Where(w => w.CNPJ.Equals(cnpj)).FirstOrDefaultAsync();
        }

        public override Task<List<Employee>> GetAllAsync()
        {
            return dbSet.AsNoTracking().OrderBy(o => o.Name).ToListAsync();
        }

        public Task<Employee> GetByUserIdAsync(int userId)
        {
            return dbSet.Where(w => w.UserId.Equals(userId)).FirstOrDefaultAsync();
        }

        public override Task<Employee> GetByIdAsync(int id)
        {
            return dbSet.Where(x => x.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public Task<int> QuantityEmployee()
        {
            return dbSet.CountAsync();
        }

        public Task<bool> CheckEmailInUse(string email, int? ignoreId)
        {
            return dbSet.Where(w => w.Email == email)
                        .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                        .AnyAsync();
        }

        public Task<bool> CheckCNPJInUse(string document, int? ignoreId)
        {
            return dbSet.Where(w => w.CNPJ == document)
                        .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                        .AnyAsync();
        }

        public Task<bool> CheckCPFInUse(string document, int? ignoreId)
        {
            return dbSet.Where(w => w.CPF == document)
                        .Where(w => (!ignoreId.HasValue || ignoreId.Value != w.Id))
                        .AnyAsync();
        }
    }
}
