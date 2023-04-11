using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Black.API.Admin.ViewModels;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.QuerieResult;
using Black.Infra.CrossCutting.Identity;
using Black.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Black.Infra.CrossCutting.Identity.Models.ManageViewModels;
using Black.Infra.Framework.Web.Attributes;
using Black.Infra.Framework.Web.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;
using Black.API.Controllers.Base;
using Black.Application.DTO;

namespace Black.API.Admin.Controllers
{
    public class UsersController : ApiBaseController
    {
        #region Properties
        private readonly UserManager<User> _userManager;
        private readonly IUserProfilePermissionApp _userProfilePermissionApp;
        private readonly IUserApp _userApp;
        private readonly IMapper _mapper;
        private readonly TokenConfigurations _tokenConfigurations;
        #endregion

        #region Construtor

        public UsersController(ILogErroApp logErroService, IUserProfilePermissionApp userProfilePermissionApp, IMapper mapper, TokenConfigurations tokenConfigurations,
                              UserManager<User> userManager, IUserApp userApp, IUser user, INotificationHandler<DomainNotification> notification)
            : base(logErroService, user, notification)
        {
            _mapper = mapper;
            _tokenConfigurations = tokenConfigurations;
            _userApp = userApp;
            _userProfilePermissionApp = userProfilePermissionApp;
            _userManager = userManager;
        }
        #endregion

        #region User Methods

        /// <summary>
        /// Retorna lista de usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.USER_VIEW })]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> GetList()
        {
            var result = await _userApp.GetAllInRoleAsync(RolesConst.SystemApp);
            var usersVm = _mapper.Map<IEnumerable<UserListDTO>>(result);

            return ResolveReturn(usersVm);
        }


        /// <summary>
        /// Retorna o usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.USER_VIEW })]
        public async Task<ActionResult<UserUpdateViewModel>> Get(int id)
        {
            var obj = await _userApp.FindById(id);
            var userVM = _mapper.Map<UserUpdateViewModel>(obj);

            return ResolveReturn(userVM);
        }

        /// <summary>
        /// Adicionar um novo usuário
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.USER_ADD })]
        public async Task<ActionResult<User>> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _userApp.Register(model, _tokenConfigurations, RolesConst.SystemApp);

            return ResolveReturn(result);
        }

        [HttpPut]
        [Permission(Permissions = new string[] { PermissionConst.USER_ADD })]
        public async Task<ActionResult<UserUpdateViewModel>> Put([FromBody] UserUpdateViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _userApp.Update(model, _tokenConfigurations);

            return ResolveReturn(result);
        }

        [HttpPut("change-password")]
        public async Task<ActionResult<bool>> ChangePassword([FromBody] ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _userApp.ChangePassword(model);

            if (!result)
                return BadRequestRegraNegocio("Não foi possível alterar a senha.");

            return ResolveReturn(result);
        }

        [HttpPut("change-password/admin")]
        [Permission(Permissions = new string[] { PermissionConst.USER_CHANGE_PASSWORD_ADMIN })]
        public async Task<ActionResult<bool>> ChangePasswordAdmin([FromBody] ChangePasswordAdminViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _userApp.ChangePasswordAdmin(model);

            if (!result)
                return BadRequestRegraNegocio("Não foi possível alterar a senha.");

            return ResolveReturn(result);
        }

        [HttpGet, Route("{id:int}/active")]
        [Permission(Permissions = new string[] { PermissionConst.USER_ADD })]
        public async Task<ActionResult<string>> Active(int id)
        {
            var result = await _userApp.ChangeStatus(id, true);
            if (!result)
                return BadRequestRegraNegocio("Não foi possível ativar o usuário.");

            return ResolveReturn(result);
        }

        [HttpGet, Route("{id:int}/inactive")]
        [Permission(Permissions = new string[] { PermissionConst.USER_ADD })]
        public async Task<ActionResult<string>> Inactive(int id)
        {
            var result = await _userApp.ChangeStatus(id, false);
            if (!result)
                return BadRequestRegraNegocio("Não foi possível inativar o usuário.");

            return ResolveReturn(result);
        }

        [HttpGet, AllowAnonymous, Route("email-check")]
        public async Task<ActionResult<string>> EmailExistente([FromQuery] string email)
        {
            var userFound = await _userManager.FindByEmailAsync(email);
            if (userFound != null)
                return BadRequestRegraNegocio("E-mail já cadastrado");
            else
                return Ok("E-mail não cadastrado");
        }

        #endregion

        [HttpGet, Route("permissions")]
        public ActionResult<GetPermissionsByIdUserQueryResult> GetPermissionsByUserLogged()
        {
            var permissions = _userProfilePermissionApp.GetPermissionByUserLogged(_user.Id.Value);
            var userPermissions = _mapper.Map<IList<PermissionsByUserLoggedViewModel>>(permissions);

            return ResolveReturn(userPermissions);
        }
    }
}
