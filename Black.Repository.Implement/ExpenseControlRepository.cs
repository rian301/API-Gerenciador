using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.Data.Context;
using Black.Repository.Implement.Base;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository.Implement
{
    public class ExpenseControlRepository : RepositoryBaseCRUD<ExpenseControl, int>, IExpenseControlRepository
    {
        public ExpenseControlRepository(ApplicationDbContext context, INotificationHandler<DomainNotification> notification) : base(context, notification)
        {
        }

        public Task<List<ExpenseControl>> GetByPeriod(DateTime dateInit, DateTime dateEnd)
        {
            return dbSet.Where(x => x.Date >= dateInit.Date && x.Date <= dateEnd.Date && x.Deleted == DeletedEnum.No)
                        .Include(i => i.Provider)
                        .Include(i => i.ExpenseCategory)
                        .OrderBy(o => o.PaymentDate)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public Task<List<ExpenseControl>> GetByPeriodAndCategories(DateTime dateInit, DateTime dateEnd, List<int> categoriesId)
        {
            return dbSet
                        .Include(i => i.Provider)
                        .Include(i => i.ExpenseCategory)
                        .Where(x => x.Date >= dateInit.Date && x.Date <= dateEnd.Date && categoriesId.Contains(x.ExpenseCategory.Id) && x.Deleted == DeletedEnum.No)
                        .OrderByDescending(o => o.PaymentDate)
                        .AsNoTracking()
                        .ToListAsync();
        }

        public IEnumerable<ExpenseControlReportQueryResult> ReportByPeriod(DateTime dateInit, DateTime dateEnd)
        {
            dateInit = dateInit.Date;
            dateEnd = dateEnd.Date;
            var sql = @"SELECT b.Name, SUM(a.Value) AS Total
	                    From ExpenseControl AS a
	                    JOIN ExpenseCategory AS b
	                    ON a.ExpenseCategoryId = b.Id
	                    WHERE a.Date >= @dateInit AND a.Date <= @dateEnd AND Deleted = 0
	                    group by b.Id,
	                    b.Name
	                    ORDER BY b.Name ASC";
            var ret = Context.Database.GetDbConnection().Query<ExpenseControlReportQueryResult>(sql, new { dateInit, dateEnd });
            return ret;
        }
    }
}
