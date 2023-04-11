using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Procard.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class InvoiceController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IInvoiceApp _app;
        #endregion

        #region Constructors
        public InvoiceController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IInvoiceApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.INVOICE_VIEW })]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<InvoiceViewModel>>(obj));
        }

        [HttpGet, Route("subscriptions/{subscriptionId:int}")]
        [Permission(Permissions = new string[] { PermissionConst.INVOICE_VIEW })]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> GetAllBySubscriptionId([FromRoute] int subscriptionId)
        {
            var obj = await _app.GetAllByIdSubscriptionAsync(subscriptionId);
            return ResolveReturn(_mapper.Map<IEnumerable<InvoiceViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.INVOICE_VIEW })]
        public async Task<ActionResult<IEnumerable<InvoiceViewModel>>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<IEnumerable<InvoiceViewModel>>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.INVOICE_ADD })]
        public async Task<ActionResult<InvoiceViewModel>> Post([FromBody] InvoiceViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Invoice>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.INVOICE_ADD })]
        public async Task<ActionResult<InvoiceViewModel>> Put(int id, [FromBody] InvoiceViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Invoice>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.INVOICE_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<InvoiceViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
