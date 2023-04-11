using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Black.API.Admin.ViewModels;
using Black.Application;
using Black.Application.DTO;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;
using Black.API.Controllers.Base;

namespace Black.API.Admin.Controllers
{
    public class ProfilesController : ApiBaseController
    {
        #region Properties
        private readonly IUserProfileApp _userProfileApp;
        private readonly IMapper _mapper;
        private readonly IUserProfilePermissionApp _userProfilePermissionApp;
        #endregion

        #region Constructors
        public ProfilesController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                  IUserProfileApp userProfileApp, IMapper mapper, IUserProfilePermissionApp userProfilePermissionApp) : base(logErroApp, user, notification)
        {
            _userProfileApp = userProfileApp;
            _mapper = mapper;
            _userProfilePermissionApp = userProfilePermissionApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.USER_PROFILE_VIEW })]
        public ActionResult<IEnumerable<UserProfileViewModel>> Get()
        {
            var obj = _userProfileApp.GetAll();
            var response = _mapper.Map<IEnumerable<UserProfileViewModel>>(obj);

            return ResolveReturn(response);
        }

        [HttpGet("{id}")]
        [Permission(Permissions = new string[] { PermissionConst.USER_PROFILE_VIEW })]
        public async Task<ActionResult<UserProfileViewModel>> Get([FromRoute] int id)
        {
            var obj = await _userProfileApp.GetByIdAsync(id);
            var response = _mapper.Map<UserProfileViewModel>(obj);

            return ResolveReturn(response);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.USER_PROFILE_ADD })]
        public async Task<ActionResult<UserProfileViewModel>> Save([FromBody] UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestModelState();

            var userProfile = new UserProfile(model.Name, _user.Id.Value);
            var userProfilePermissions = _mapper.Map<IList<UserProfilePermission>>(model.Permissions);

            userProfile.AddPermission(userProfilePermissions, _user.Id.Value);

            var id = await _userProfileApp.AddAsync(userProfile);

            return ResolveReturn(id);

        }

        [HttpPut]
        [Permission(Permissions = new string[] { PermissionConst.USER_PROFILE_ADD })]
        public async Task<ActionResult<UserProfileViewModel>> Update([FromBody] UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestModelState();

            var updateProfile = _mapper.Map<DTOChangeUserProfile>(model);
            await _userProfileApp.UpdateAsync(updateProfile);

            return ResolveReturn(model.Id);

        }

        [HttpGet, Route("permissions")]
        [Permission(Permissions = new string[] { PermissionConst.USER_PROFILE_VIEW, PermissionConst.USER_PROFILE_ADD })]
        public ActionResult<IEnumerable<PermissionViewModel>> GetAllPermissions()
        {
            var permissions = _userProfilePermissionApp.GetAllPermissions();

            var permissionsVm = _mapper.Map<IList<PermissionViewModel>>(permissions);
            return ResolveReturn(permissionsVm);
        }

        #endregion
    }
}
