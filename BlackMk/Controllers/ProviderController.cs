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
    public class ProviderController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IProviderApp _app;
        #endregion

        #region Constructors
        public ProviderController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IProviderApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.PROVIDER_VIEW })]
        public async Task<ActionResult<IEnumerable<ProviderViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<ProviderViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PROVIDER_VIEW })]
        public async Task<ActionResult<ProviderViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<ProviderViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.PROVIDER_ADD })]
        public async Task<ActionResult<ProviderViewModel>> Post([FromBody] ProviderViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Provider>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PROVIDER_ADD })]
        public async Task<ActionResult<ProviderViewModel>> Put(int id, [FromBody] ProviderViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Provider>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.PROVIDER_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<ProviderViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
