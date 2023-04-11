using AutoMapper;
using Black.API.Admin.ViewModels;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Application.DTO;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Black.API.Admin.Controllers
{
    public class ReportsController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IInvoiceApp _invoiceApp;
        private readonly ISubscriptionApp _subscriptionApp;
        private readonly IExpenseControlApp _expenseControlApp;
        public ISubscriptionApp SubscriptionApp => _subscriptionApp;
        #endregion

        #region Contructor
        public ReportsController(IInvoiceApp invoice, IMapper mapper, ILogErroApp logErroApp, IUser user, ISubscriptionApp subscriptionApp, IExpenseControlApp expenseControlApp, INotificationHandler<DomainNotification> notification) : base(logErroApp, user, notification)
        {
            _invoiceApp = invoice;
            _mapper = mapper;
            _subscriptionApp = subscriptionApp;
            _expenseControlApp = expenseControlApp;
        }
        #endregion

        [HttpGet("invoices")]
        [Permission(Permissions = new string[] { PermissionConst.REPORT_INVOICE_VIEW_MENTORED })]
        public async Task<ActionResult<List<InvoiceReportViewModel>>> GetAllInvoicesByPeriod(DateTime datInit, DateTime datEnd, bool paid)
        {
            var report = await _invoiceApp.GetInvoicesByPeriod(datInit, datEnd, paid);
            return ResolveReturn(_mapper.Map<List<InvoiceReportViewModel>>(report));
        }

        [HttpGet("subscriptions")]
        [Permission(Permissions = new string[] { PermissionConst.REPORT_INVOICE_VIEW_MENTORED })]
        public async Task<ActionResult<List<SubscriptionReportViewModel>>> GetAllSubscriptionsByPeriod(DateTime? date)
        {
            var report = await _subscriptionApp.GetAllByDateAsync(date);
            return ResolveReturn(_mapper.Map<List<SubscriptionReportViewModel>>(report));
        }

        [HttpPost("expense-control")]
        [Permission(Permissions = new string[] { PermissionConst.REPORT_INVOICE_VIEW_MENTORED })]
        public async Task<ActionResult<BlobFileDTO>> GetallExpenseByPeriod(ReportExpenseControlViewModel model)
        {
            var file = await _expenseControlApp.ReportExpenseControl(model.DatInit, model.DatEnd, model.TypeReport, model.Categories);

            using var streamfile = new MemoryStream();
            var contantType = "application/pdf";

            return File(file.ToArray(), contantType, "");
        }
    }
}
