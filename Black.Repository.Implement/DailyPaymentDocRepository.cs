﻿using Black.Domain.Core.Notifications;
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
    public class DailyPaymentDocRepository : RepositoryBaseCRUD<DailyPaymentDoc, Guid>, IDailyPaymentDocRepository
	{
		public DailyPaymentDocRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
		{
		}

		public Task<DailyPaymentDoc> GetByFileNameAsync(string filename)
		{
			return dbSet.Where(w => w.FileName.Equals(filename)).FirstOrDefaultAsync();
		}

		public Task<List<DailyPaymentDoc>> GetAllByDailyPaymentIdAsync(int dailyId)
		{
			return dbSet.AsNoTracking()
						.Where(w => w.DailyPaymentId == dailyId)
						.OrderByDescending(o => o.CreatedAt)
						.OrderBy(o => o.TypeDoc)
						.ToListAsync();
		}

        public Task<List<DailyPaymentDoc>> GetAllActives(int mentoredCompanyId)
        {
            return dbSet.AsNoTracking().Where(w => w.Active).OrderBy(o => o.TypeDoc).ToListAsync();
        }

        public Task<DailyPaymentDoc> GetDocsActivesbyType(int mentoredCompanyId, TypeDocEnum typedoc)
        {
            return dbSet.AsNoTracking().Where(w => w.TypeDoc == typedoc && w.Active).FirstOrDefaultAsync();
        }

        public Task<DailyPaymentDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc)
		{
			return dbSet.AsNoTracking().Where(w => w.Id == docId && w.DailyPaymentId == mentoredId && w.TypeDoc == typedoc).FirstOrDefaultAsync();
		}
	}
}
