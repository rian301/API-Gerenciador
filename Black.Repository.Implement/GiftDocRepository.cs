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
    public class GiftDocRepository : RepositoryBaseCRUD<GiftDoc, Guid>, IGiftDocRepository
	{
		public GiftDocRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
		{
		}

		public Task<GiftDoc> GetByFileNameAsync(string filename)
		{
			return dbSet.Where(w => w.FileName.Equals(filename)).FirstOrDefaultAsync();
		}

		public Task<List<GiftDoc>> GetAllByGiftIdAsync(int mentoredId)
		{
			return dbSet.AsNoTracking()
						.Where(w => w.GiftId == mentoredId)
						.OrderByDescending(o => o.CreatedAt)
						.OrderBy(o => o.CreatedAt)
						.ToListAsync();
		}

		public Task<List<GiftDoc>> GetAllActives(int employeeId)
        {
			return dbSet.AsNoTracking().Where(w => w.GiftId == employeeId && w.Active).OrderBy(o => o.CreatedAt).ToListAsync();
		}

		public Task<GiftDoc> GetDocsActivesbyType(int employeeId, TypeDocEnum typeDoc)
		{
			return dbSet.AsNoTracking().Where(w => w.GiftId == employeeId && w.TypeDoc == typeDoc && w.Active).FirstOrDefaultAsync();
		}

		public Task<GiftDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typeDoc)
		{
			return dbSet.AsNoTracking().Where(w => w.Id == docId && w.GiftId == mentoredId && w.TypeDoc == typeDoc).FirstOrDefaultAsync();
		}
	}
}
