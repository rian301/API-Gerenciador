using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Application.DTO;
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
    public class LaunchController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ILaunchApp _launchApp;
        #endregion

        #region Constructors
        public LaunchController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   ILaunchApp launchApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _launchApp = launchApp;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.LAUNCH_VIEW })]
        public async Task<ActionResult<IEnumerable<LaunchViewModel>>> GetAll()
        {
            var obj = _launchApp.GetAll();
            var objVM = _mapper.Map<IEnumerable<LaunchViewModel>>(obj);

            return ResolveReturn(objVM);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.LAUNCH_VIEW })]
        public async Task<ActionResult<LaunchViewModel>> Get(int id)
        {
            var obj = await _launchApp.GetByIdAsync(id);
            var objVM = _mapper.Map<LaunchViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.LAUNCH_ADD })]
        public async Task<ActionResult<LaunchViewModel>> Post([FromBody] LaunchViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Launch>(model);

            var result = await _launchApp.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.LAUNCH_ADD })]
        public async Task<ActionResult<LaunchViewModel>> Put(int id, [FromBody] LaunchViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var dto = _mapper.Map<LaunchDTO>(model);

            var result = await _launchApp.UpdateAsync(dto);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.LAUNCH_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<LaunchViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _launchApp.DeleteAsync(id);
            return ResolveReturn(ret);
        }

        #endregion
    }
}
