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
    [Route("customers/{customerId}/launch")]
    public class CustomerLaunchController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ICustomerLaunchApp _app;
        #endregion

        #region Constructors
        public CustomerLaunchController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   ICustomerLaunchApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<IEnumerable<CustomerLaunchViewModel>>> GetAllByCustomer(int customerId)
        {
            var obj = await _app.GetAllLaunchByCustomer(customerId);
            return ResolveReturn(_mapper.Map<IEnumerable<CustomerLaunchViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<CustomerLaunchViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<CustomerLaunchViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerLaunchViewModel>> Post([FromBody] CustomerLaunchViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<CustomerLaunch>(model);
            obj.CustomerId = customerId;

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerLaunchViewModel>> Put(int id, [FromBody] CustomerLaunchViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            //var dto = _mapper.Map<LaunchDTO>(model);
            var obj = _mapper.Map<CustomerLaunch>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<CustomerLaunchViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
