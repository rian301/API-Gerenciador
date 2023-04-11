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
    [Route("mentored/{mentoredId}/company")]
    public class MentoredCompanyController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IMentoredCompanyApp _app;
        #endregion

        #region Constructors
        public MentoredCompanyController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IMentoredCompanyApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentoredCompanyViewModel>>> GetAllByCustomer(int mentoredId)
        {
            var obj = await _app.GetAllCompanyByMentored(mentoredId);
            return ResolveReturn(_mapper.Map<IEnumerable<MentoredCompanyViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredCompanyViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<MentoredCompanyViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredCompanyViewModel>> Post([FromBody] MentoredCompanyViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<MentoredCompany>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredCompanyViewModel>> Put(int id, [FromBody] MentoredCompanyViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<MentoredCompany>(model);
            obj.ChangedAt = System.DateTime.Now;

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<MentoredCompanyViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
