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
    public class AwardController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IAwardApp _app;
        #endregion

        #region Constructors
        public AwardController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IAwardApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.AWARD_VIEW })]
        public async Task<ActionResult<IEnumerable<AwardViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<AwardViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.AWARD_VIEW })]
        public async Task<ActionResult<AwardViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<AwardViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.AWARD_ADD })]
        public async Task<ActionResult<AwardViewModel>> Post([FromBody] AwardViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Award>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.AWARD_ADD })]
        public async Task<ActionResult<AwardViewModel>> Put(int id, [FromBody] AwardViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Award>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.AWARD_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<AwardViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
