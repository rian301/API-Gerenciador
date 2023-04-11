using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IExpenseControlService : IServiceBaseCRUD<ExpenseControl, int>
    {
        Task<List<ExpenseControl>> GetByPeriod(DateTime dateInit, DateTime dateEnd);
        IEnumerable<ExpenseControlReportQueryResult> ReportByPeriod(DateTime dateInit, DateTime dateEnd);
        Task<List<ExpenseControl>> GetByPeriodAndCategories(DateTime dateInit, DateTime dateEnd, List<int> categoriesId);
    }
}
