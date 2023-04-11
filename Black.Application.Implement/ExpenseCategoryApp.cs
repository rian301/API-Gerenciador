using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class ExpenseCategoryApp : AppBaseCRUD<ExpenseCategory, int>, IExpenseCategoryApp
    {
        #region Properties
        private readonly IExpenseCategoryService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public ExpenseCategoryApp(IExpenseCategoryService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion
        public Task<int> QuantityExpenseCategorys() => _service.QuantityExpenseCategorys();
    }
}
