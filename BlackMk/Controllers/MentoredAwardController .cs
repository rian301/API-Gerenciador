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
    [Route("mentoreds/{mentoredId}/award")]
    public class MentoredAwardController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IMentoredAwardApp _app;
        #endregion

        #region Constructors
        public MentoredAwardController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IMentoredAwardApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<IEnumerable<MentoredAwardViewModel>>> GetAllByCustomer(int mentoredId)
        {
            var obj = await _app.GetAllAwardByMentored(mentoredId);
            return ResolveReturn(_mapper.Map<IEnumerable<MentoredAwardViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<MentoredAwardViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<MentoredAwardViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<MentoredAwardViewModel>> Post([FromBody] MentoredAwardViewModel model, int mentoredId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<MentoredAward>(model);
            obj.MentoredId = mentoredId;
            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<MentoredAwardViewModel>> Put(int id, [FromBody] MentoredAwardViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<MentoredAward>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<MentoredAwardViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
