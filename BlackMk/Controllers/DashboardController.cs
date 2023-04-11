using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Black.API.Admin.ViewModels;
using Black.Application;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using System.Threading.Tasks;
using Black.API.Controllers.Base;

namespace Black.API.Admin.Controllers
{
    public class DashboardController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ICustomerApp _customerApp;
        private readonly ILaunchApp _launchApp;
        private readonly IProductApp _productApp;
        private readonly IAwardApp _awardApp;
        #endregion

        #region Constructors
        public DashboardController(ILogErroApp logErroApp, IUser user, ILaunchApp launchApp, IProductApp productApp, IAwardApp awardApp, INotificationHandler<DomainNotification> notification, IMapper mapper, ICustomerApp customerApp) 
                : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _customerApp = customerApp;
            _launchApp = launchApp;
            _productApp = productApp;
            _awardApp = awardApp;
        }

        #endregion

        [HttpGet()]
        public async Task<ActionResult<DashboardViewModel>> GetAgentStatusInAnalisys()
        {
            var customerAll = await _customerApp.QuantityCustomers();
            var launchAll = await _launchApp.QuantityLaunch();
            var productAll = await _productApp.QuantityProducts();
            var awardAll = await _awardApp.QuantityAwards();
            var dash = new DashboardViewModel
            {
                CustomerCount = customerAll,
                LaunchCount = launchAll,
                ProductCount = productAll,
                AwardCount = awardAll
            };
            return ResolveReturn(dash);
        }
    }
}
