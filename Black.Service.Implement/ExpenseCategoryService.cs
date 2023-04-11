using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class ExpenseCategoryService : ServiceBaseCRUD<ExpenseCategory, int>, IExpenseCategoryService
    {
        #region Properties
        private readonly IExpenseCategoryRepository _repository;
        #endregion

        public ExpenseCategoryService(IExpenseCategoryRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityExpenseCategorys() => _repository.QuantityExpenseCategorys();
    }
}
