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
    public class MentoredPaymentService : ServiceBaseCRUD<MentoredPayment, int>, IMentoredPaymentService
    {
        #region Properties
        private readonly IMentoredPaymentRepository _repository;
        #endregion

        public MentoredPaymentService(IMentoredPaymentRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<MentoredPayment>> GetAllByMentoredIdAsync(int mentoredId) => _repository.GetAllByMentoredIdAsync(mentoredId);
    }
}
