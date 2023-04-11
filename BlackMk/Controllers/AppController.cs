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
    public class AppController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAppApp _app;
        #endregion

        #region Constructors
        public AppController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IAppApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.APP_VIEW })]
        public async Task<ActionResult<IEnumerable<AppViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<AppViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.APP_VIEW })]
        public async Task<ActionResult<AppViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<AppViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.APP_ADD })]
        public async Task<ActionResult<AppViewModel>> Post([FromBody] AppViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<App>(model);

            var result = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<AppViewModel>(result));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.APP_ADD })]
        public async Task<ActionResult<AppViewModel>> Put(int id, [FromBody] AppViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<App>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            var result = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<AppViewModel>(result));
        }

        [Permission(Permissions = new string[] { PermissionConst.APP_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<AppViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
