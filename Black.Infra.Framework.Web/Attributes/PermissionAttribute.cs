using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Black.Application;
using Black.Domain.Interfaces;
using Black.Application.Implement;

namespace Black.Infra.Framework.Web.Attributes
{
    public class PermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string[] Permissions { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var _user = (IUser)context.HttpContext.RequestServices.GetService(typeof(IUser));
            var _permissionValidateApp = (PermissionValidateApp)context.HttpContext.RequestServices.GetService(typeof(IPermissionValidateApp));

            bool isAuthorized = _permissionValidateApp.ValidateUserPermission(_user.Id.Value, Permissions);

            if (!isAuthorized)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            return;

        }
    }
}
