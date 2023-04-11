using Microsoft.AspNetCore.Authorization;
using Black.Application;
using Black.Domain.Core.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Infra.Framework.Web.Controller;

namespace Black.API.Controllers.Base
{
    [Authorize(Roles = nameof(RolesConst.SystemApp))]
    public class ApiBaseController : BaseController
    {
        public ApiBaseController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification) : base(logErroApp, user, notification)
        {
        }
    }
}
