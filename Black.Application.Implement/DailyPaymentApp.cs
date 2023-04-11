using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class DailyPaymentApp : AppBaseCRUD<DailyPayment, int>, IDailyPaymentApp
    {
        #region Properties
        private readonly IDailyPaymentService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public DailyPaymentApp(IDailyPaymentService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion
        public Task<int> QuantityDailyPayments() => _service.QuantityDailyPayments();

        public async Task<DailyPayment> AddDailyPayment(DailyPayment model)
        {
            var daily = new DailyPayment(model.Name, model.DatePayment, model.DateSchedulingPayment, model.Amount, model.Document, model.Bank, model.Agency, model.Acount, model.Pix, model.Note, model.ProviderId, model.CategoryId);
            if (!daily.IsValid())
            {
                _notification.Handle(daily.ValidationResult.Errors);
                return null;
            }
            await base.UpdateAsync(daily);

            return daily;
        }

        public async Task<List<DailyPayment>> GetAllPagination(QueryDailyPaymentDTO query) 
        {
            var pageOptions = new PaginationDTO(query.PageIndex, query.PageSize);
            var result = await _service.GetAllPagination(query.Name, query.DateScheduled, query.Provider, query.Category, pageOptions);
            return result;
        }
    }
}
