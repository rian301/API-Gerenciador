using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class DailyPaymentService : ServiceBaseCRUD<DailyPayment, int>, IDailyPaymentService
    {
        #region Properties
        private readonly IDailyPaymentRepository _repository;
        #endregion

        public DailyPaymentService(IDailyPaymentRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityDailyPayments() => _repository.QuantityDailyPayments();

        public Task<List<DailyPayment>> GetAllPagination(string name, DateTime? date, string provider, string category, PaginationDTO pagination) => _repository.GetAllPagination(name, date, provider, category, pagination);
    }
}
