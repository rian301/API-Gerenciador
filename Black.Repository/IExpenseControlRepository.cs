using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IExpenseControlRepository : IRepositoryBaseCRUD<ExpenseControl, int>
    {
        Task<List<ExpenseControl>> GetByPeriod(DateTime dateInit, DateTime dateEnd);
        IEnumerable<ExpenseControlReportQueryResult> ReportByPeriod(DateTime dateInit, DateTime dateEnd);
        Task<List<ExpenseControl>> GetByPeriodAndCategories(DateTime dateInit, DateTime dateEnd, List<int> categoriesId);
    }
}
