using AutoMapper;
using Black.API.Admin.ViewModels;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class PendencyController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IPendencyApp _app;
        #endregion

        #region Constructors
        public PendencyController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IPendencyApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.PENDENCY_VIEW })]
        public async Task<ActionResult<IEnumerable<PendencyViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<PendencyViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PENDENCY_VIEW })]
        public async Task<ActionResult<PendencyViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<PendencyViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.PENDENCY_ADD })]
        public async Task<ActionResult<PendencyViewModel>> Post([FromBody] PendencyViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Pendency>(model);
            var result = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<PendencyViewModel>(result));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PENDENCY_ADD })]
        public async Task<ActionResult<PendencyViewModel>> Put(int id, [FromBody] PendencyViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Pendency>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [HttpPut, Route("{id:int}/status/{status}")]
        [Permission(Permissions = new string[] { PermissionConst.PENDENCY_ADD })]
        public async Task<ActionResult<bool>> ChangeStatusCompany(int id, PendencyStatusEnum status)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _app.StatusChangeAsync(id, status);

            return ResolveReturn(result);
        }

        [Permission(Permissions = new string[] { PermissionConst.PENDENCY_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<PendencyViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
