using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class PurchaseControlService : ServiceBaseCRUD<PurchaseControl, int>, IPurchaseControlService
    {
        #region Properties
        private readonly IPurchaseControlRepository _repository;
        #endregion

        public PurchaseControlService(IPurchaseControlRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityPurchaseControls() => _repository.QuantityPurchaseControls();
        public Task<IQueryable<PurchaseControl>> GetAllPagination(string requestName, string description, DateTime? dateSolicitation, DateTime? datePurchase, DateTime? dateDelivery, PaginationDTO pagination) => _repository.GetAllPagination(requestName, description, dateSolicitation, datePurchase, dateDelivery, pagination);
    }
}
