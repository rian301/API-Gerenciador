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
    public class MentoredDocRepository : RepositoryBaseCRUD<MentoredDoc, Guid>, IMentoredDocRepository
	{
		public MentoredDocRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
		{
		}

		public Task<MentoredDoc> GetByFileNameAsync(string filename)
		{
			return dbSet.Where(w => w.FileName.Equals(filename)).FirstOrDefaultAsync();
		}

		public Task<List<MentoredDoc>> GetAllByMentoredIdAsync(int mentoredId)
		{
			return dbSet.AsNoTracking()
						.Where(w => w.MentoredId == mentoredId)
						.OrderBy(o => o.CreatedAt)
						.ToListAsync();
		}

		public Task<List<MentoredDoc>> GetAllActives(int mentoredCompanyId)
        {
			return dbSet.AsNoTracking().Where(w => w.MentoredCompanyId == mentoredCompanyId && w.Active).OrderBy(o => o.TypeDoc).ToListAsync();
		}

		public Task<MentoredDoc> GetDocsActivesbyType(int mentoredCompanyId, TypeDocEnum typedoc)
		{
			return dbSet.AsNoTracking().Where(w => w.MentoredCompanyId == mentoredCompanyId && w.TypeDoc == typedoc && w.Active).FirstOrDefaultAsync();
		}

		public Task<MentoredDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc)
		{
			return dbSet.AsNoTracking().Where(w => w.Id == docId && w.MentoredId == mentoredId && w.TypeDoc == typedoc).FirstOrDefaultAsync();
		}
	}
}
