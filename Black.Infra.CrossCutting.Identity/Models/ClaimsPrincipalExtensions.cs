using System;
using System.Security.Claims;

namespace Black.Infra.CrossCutting.Identity.Models
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var claim = principal.FindFirst("Codigo");
            return claim?.Value;
        }
    }
}
