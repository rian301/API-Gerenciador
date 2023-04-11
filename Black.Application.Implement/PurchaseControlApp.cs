using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class PurchaseControlApp : AppBaseCRUD<PurchaseControl, int>, IPurchaseControlApp
    {
        #region Properties
        private readonly IPurchaseControlService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public PurchaseControlApp(IPurchaseControlService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }

        public async Task<IQueryable<PurchaseControl>> GetAllPagination(PurchaseControlFilterDto query)
        {
            var pageOptions = new PaginationDTO(query.PageIndex, query.PageSize);
            var result = await _service.GetAllPagination(query.RequestName, query.Description, query.DateSolicitation, query.DatePurchase, query.DateDelivery, pageOptions);
            return result;
        }
        #endregion
    }
}
