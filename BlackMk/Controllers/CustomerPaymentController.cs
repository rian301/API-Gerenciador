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
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    [Route("customers/{customerId}/payment")]
    public class CustomerPaymentController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ICustomerPaymentApp _app;
        #endregion

        #region Constructors
        public CustomerPaymentController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   ICustomerPaymentApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<IEnumerable<CustomerPaymentViewModel>>> GetAllByCustomer(int customerId)
        {
            var obj = await _app.GetAllPaymentByCustomer(customerId);
            return ResolveReturn(_mapper.Map<IEnumerable<CustomerPaymentViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<CustomerPaymentViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<CustomerPaymentViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerPaymentViewModel>> Post([FromBody] CustomerPaymentViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<CustomerPayment>(model);
            obj.CustomerId = customerId;
            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerPaymentViewModel>> Put(int id, [FromBody] CustomerPaymentViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<CustomerPayment>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<CustomerPaymentViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
