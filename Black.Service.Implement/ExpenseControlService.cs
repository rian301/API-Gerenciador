using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class ExpenseControlService : ServiceBaseCRUD<ExpenseControl, int>, IExpenseControlService
    {
        #region Properties
        private readonly IExpenseControlRepository _repository;
        #endregion

        public ExpenseControlService(IExpenseControlRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<ExpenseControl>> GetByPeriod(DateTime dateInit, DateTime dateEnd) => _repository.GetByPeriod(dateInit, dateEnd);
        public IEnumerable<ExpenseControlReportQueryResult> ReportByPeriod(DateTime dateInit, DateTime dateEnd) => _repository.ReportByPeriod(dateInit, dateEnd);
        public Task<List<ExpenseControl>> GetByPeriodAndCategories(DateTime dateInit, DateTime dateEnd, List<int> categoriesId) => _repository.GetByPeriodAndCategories(dateInit, dateEnd, categoriesId);

    }
}
