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
    public class    GiftController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IGiftApp _app;
        #endregion

        #region Constructors
        public GiftController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IGiftApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.GIFT_VIEW })]
        public async Task<ActionResult<IEnumerable<GiftViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<GiftViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.GIFT_VIEW })]
        public async Task<ActionResult<GiftViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<GiftViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.GIFT_ADD })]
        public async Task<ActionResult<GiftViewModel>> Post([FromBody] GiftViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Gift>(model);

            var result = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<GiftViewModel>(result));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.GIFT_ADD })]
        public async Task<ActionResult<GiftViewModel>> Put(int id, [FromBody] GiftViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Gift>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            var result = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<GiftViewModel>(result));
        }

        [Permission(Permissions = new string[] { PermissionConst.GIFT_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<GiftViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
