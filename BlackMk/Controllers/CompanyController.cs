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
    public class CompanyController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IMentoredCompanyApp _app;
        #endregion

        #region Constructors
        public CompanyController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IMentoredCompanyApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MentoredCompanyViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<MentoredCompanyViewModel>>(obj));
        }
        #endregion
    }
}
