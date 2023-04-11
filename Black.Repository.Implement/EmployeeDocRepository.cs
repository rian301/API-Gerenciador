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
    public class EmployeeDocRepository : RepositoryBaseCRUD<EmployeeDoc, Guid>, IEmployeeDocRepository
	{
		public EmployeeDocRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
		{
		}

		public Task<EmployeeDoc> GetByFileNameAsync(string filename)
		{
			return dbSet.Where(w => w.FileName.Equals(filename)).FirstOrDefaultAsync();
		}

		public Task<List<EmployeeDoc>> GetAllByEmployeeIdAsync(int mentoredId)
		{
			return dbSet.AsNoTracking()
						.Where(w => w.EmployeeId == mentoredId)
						.OrderByDescending(o => o.CreatedAt)
						.OrderBy(o => o.CreatedAt)
						.ToListAsync();
		}

		public Task<List<EmployeeDoc>> GetAllActives(int employeeId)
        {
			return dbSet.AsNoTracking().Where(w => w.EmployeeId == employeeId && w.Active).OrderBy(o => o.CreatedAt).ToListAsync();
		}

		public Task<EmployeeDoc> GetDocsActivesbyType(int employeeId, TypeDocEnum typeDoc)
		{
			return dbSet.AsNoTracking().Where(w => w.EmployeeId == employeeId && w.TypeDoc == typeDoc && w.Active).FirstOrDefaultAsync();
		}

		public Task<EmployeeDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typeDoc)
		{
			return dbSet.AsNoTracking().Where(w => w.Id == docId && w.EmployeeId == mentoredId && w.TypeDoc == typeDoc).FirstOrDefaultAsync();
		}
	}
}
