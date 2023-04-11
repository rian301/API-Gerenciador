using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Black.API.Controllers.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Infra.CrossCutting.Identity.Models.AccountViewModels;
using Black.Infra.Framework.Web.Authentication;
using System.Threading.Tasks;
using Black.Application;
using Black.Domain.Core.Consts;
using Black.Infra.CrossCutting.Identity;

namespace Black.API.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiBaseController
    {
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IUserApp _userApp;

        public AuthController(ILogErroApp logErroService, IUser user, INotificationHandler<DomainNotification> notification,
                TokenConfigurations tokenConfigurations, IUserApp userApp)
            : base(logErroService, user, notification)
        {
            _tokenConfigurations = tokenConfigurations;
            _userApp = userApp;
        }

        [HttpPost]
        public async Task<ActionResult<TokenViewModel>> GenerateToken([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestModelState();

            return ResolveReturn(await _userApp.GenerateToken(model, _tokenConfigurations));
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Post([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _userApp.Register(model, _tokenConfigurations, RolesConst.SystemApp);

            return ResolveReturn(result);
        }

        [HttpPost("recover-password")]
        public async Task<ActionResult<string>> RecoverPassword([FromBody] ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestModelState();

            var result = await _userApp.PasswordRecovery(model.Email, _tokenConfigurations);
            if (result)
                return ResolveReturn(new { Message = "Enviamos um e-mail com instruções para redefinição de senha." });

            return BadRequestRegraNegocio("Não encontramos o e-mail informado. Verifique o e-mail e tente novamente.");
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequestModelState();

            var result = await _userApp.ResetPassword(model);
            if (result)
                return ResolveReturn(new { Message = "Senha alterada com sucesso." });

            return BadRequestRegraNegocio("Requisição inválida");
        }
    }
}
