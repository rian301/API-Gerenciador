using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class MentoredPaymentApp : AppBaseCRUD<MentoredPayment, int>, IMentoredPaymentApp
    {
        #region Properties
        private readonly IMentoredPaymentService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        private readonly ISubscriptionApp _subscriptionApp;
        private readonly IInvoiceApp _invoiceApp;
        private readonly ILogErroApp _logErroApp;
        private readonly IInvoiceService _invoiceService;
        #endregion

        #region Constructors
        public MentoredPaymentApp(IMentoredPaymentService service, INotificationHandler<DomainNotification> notification, IInvoiceService invoiceService, ILogErroApp logErroApp, IUser user, IUserApp userApp, IInvoiceApp invoiceApp, ISubscriptionApp subscriptionApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
            _invoiceApp = invoiceApp;
            _subscriptionApp = subscriptionApp;
            _logErroApp = logErroApp;
            _invoiceService = invoiceService;
        }
        #endregion

        public Task<List<MentoredPayment>> GetAllByMentoredIdAsync(int mentoredId) => _service.GetAllByMentoredIdAsync(mentoredId);

        public async Task<bool> CreateOrUpdate(MentoredPutPaymentDTO dto)
        {
            if (dto.Id != null)
            {
                var subscription = await _subscriptionApp.GetByIdAsync(dto.Id.Value);

                subscription.Update(dto.ProductId, dto.MentoredId, dto.MentoredCompanyId, dto.CanceledDate,
                dto.SubscriptionDate, dto.EndSubscriptionDate, dto.CurrentPeriodId, dto.MotiveCanceled, dto.OverdueSince, dto.RequestCancelDate,
                dto.DueDate, dto.RequestCancelMotive, dto.InitialAmount, dto.TotalAmount, dto.DiscountAmount, dto.Installments);

                var result = await _subscriptionApp.UpdateAsync(subscription);

                if (!result)
                {
                    _notification.Handle(new DomainNotification("SubscriptionUpdateError", "Não foi possível atualizar a inscrição. Verifique os dados e tente novamente."));
                    return false;
                }

                await Invoices(subscription.Id, dto.Invoices, true);
            }
            else
            {
                var subs = new Subscription(dto.ProductId, dto.MentoredId, dto.MentoredCompanyId, dto.CanceledDate,
                    dto.SubscriptionDate, dto.EndSubscriptionDate, dto.CurrentPeriodId, dto.MotiveCanceled, dto.OverdueSince, dto.RequestCancelDate,
                    dto.DueDate, dto.RequestCancelMotive, dto.InitialAmount, dto.TotalAmount, dto.DiscountAmount, dto.Installments);

                subs.ChangeStatus(SubscriptionStatusEnum.Active);

                // Salvar a subscription
                var resultSub = await _subscriptionApp.AddAsync(subs);

                if (!resultSub)
                {
                    _notification.Handle(new DomainNotification("SubscriptionError", "Não foi possível criar a inscrição. Verifique os dados e tente novamente."));
                    return false;
                }

                await Invoices(subs.Id, dto.Invoices);
                return resultSub;
            }
            return true;
        }

        public async Task<bool> ChangeStatusSubscription(SubscriptionStatusEnum status, int id)
        {
            var sub = await _subscriptionApp.GetByIdAsync(id);

            if (sub == null)
            {
                _notification.Handle(new DomainNotification("SubscriptionNotFound", "Assinatura não encontrada."));
                return false;
            }

            sub.ChangeStatus(status);

            if (sub.Status == SubscriptionStatusEnum.Canceled)
                await ChangeStatusInvoice(sub.Id);

            await _subscriptionApp.UpdateAsync(sub);
            await _uow.SaveAsync();
            return true;
        }

        public async Task Invoices(int subscriptionId, List<InvoiceDTO> invoiceListDTO, bool isUpdate = false)
        {
            //await ChangeStatusSubscription(SubscriptionStatusEnum.Conclude, subscriptionId);
            var result = invoiceListDTO.Any(x => x.PaidDate == null);
            if (result)
            {
                await ChangeStatusSubscription(SubscriptionStatusEnum.Active, subscriptionId);
            }
            else
            {
                await ChangeStatusSubscription(SubscriptionStatusEnum.Conclude, subscriptionId);
            }
            foreach (var item in invoiceListDTO)
            {
                if (item.Id != null && isUpdate)
                {
                    var invoiceUpdate = await _invoiceApp.GetByIdAsync(item.Id.Value);
                    invoiceUpdate.Update(subscriptionId, item.MentoredId, item.Amount.Value, item.NextAttempt, item.ExpirationDate, item.PaidDate);

                    if (item.PaidDate != null)
                        invoiceUpdate.SetStatus(InvoiceStatusEnum.Approved);
                    else
                    {
                        invoiceUpdate.SetStatus(InvoiceStatusEnum.Pending);
                        await ChangeStatusSubscription(SubscriptionStatusEnum.Active, subscriptionId);
                    }

                    await _invoiceApp.UpdateAsync(invoiceUpdate);
                }
                else
                {
                    var invoice = new Invoice(subscriptionId, item.MentoredId, item.Amount.Value, item.NextAttempt, item.ExpirationDate, item.PaidDate);
                    if (item.PaidDate != null)
                        invoice.SetStatus(InvoiceStatusEnum.Approved);

                    var resultInvoice = await _invoiceApp.AddAsync(invoice);

                    if (!resultInvoice)
                    {
                        _notification.Handle(new DomainNotification("InvoiceError", "Não foi possível criar as faturas. Verifique os dados e tente novamente."));
                    }
                }
            }
        }

        public async Task<bool> ChangeStatusInvoice(int subscriptionId)
        {
            var invoices = await _invoiceService.GetAllPendingBySubscription(subscriptionId);

            if (invoices.Count <= 0)
                return false;

            foreach (var item in invoices)
            {
                item.SetStatus(InvoiceStatusEnum.Canceled);
            }
            return true;
        }
    }
}
