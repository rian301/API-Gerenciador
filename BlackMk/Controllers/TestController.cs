using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Procard.Black.Admin.Controllers
{

    [Route("test")]
    public class TestController : ControllerBase
    {

        [HttpGet]
        [AllowAnonymous]
        public async Task<string> Get()
        {
            return "API ON";
        }
    }
}
