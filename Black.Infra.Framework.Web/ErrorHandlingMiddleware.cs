using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.CrossCutting.Common.Json;
using Black.Service;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Black.Infra.Framework.Web.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        private static JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings() {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented
        };

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogErroService logErroService, IUser user)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                var classe = ex.TargetSite.DeclaringType.FullName + "." + ex.TargetSite.Name;
                string dados = null;
                if (context.Request.QueryString.HasValue)
                    dados = context.Request.QueryString.Value;
                else
                    dados = context.Request.ToString();

                string sUser = (user != null ? JsonConvert.SerializeObject(user, jsonSerializerSettings) : null);

                logErroService.Insert(new LogErro(1, classe, ex.ToString(), sUser, dados));

                await HandleExceptionAsync(context);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context)
        {
            var code = HttpStatusCode.BadRequest; // 500 if unexpected

            var result = JsonConvert.SerializeObject(new JsonRetornoDefault("Ocorreu um erro ao processar a solicitação."), jsonSerializerSettings);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
