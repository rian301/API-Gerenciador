using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Application.DTO;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using Black.Infra.Framework.Web.Authentication;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.API.Controllers
{
    public class MentoredPaymentController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IMentoredPaymentApp _mentoredPayment;
        private readonly IPaymentMethodApp _paymentMethodApp;
        private readonly IMentoredApp _mentored;
        private readonly ISubscriptionApp _subscriptionApp;
        private readonly TokenConfigurations _tokenConfigurations;
        #endregion

        #region Constructors
        public MentoredPaymentController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification, IMapper mapper,
            IMentoredPaymentApp checkoutApp, IPaymentMethodApp paymentMethodApp, IMentoredApp mentoredApp, ISubscriptionApp subscriptionApp, TokenConfigurations tokenConfigurations) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _mentoredPayment = checkoutApp;
            _paymentMethodApp = paymentMethodApp;
            _mentored = mentoredApp;
            _tokenConfigurations = tokenConfigurations;
            _subscriptionApp = subscriptionApp;
        }

        #endregion

        #region Methods
        [HttpGet, Route("{mentoredId:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<IEnumerable<MentoredPaymentListViewModel>>> GetAll([FromRoute] int mentoredId)
        {
            var obj = await _mentoredPayment.GetAllByMentoredIdAsync(mentoredId);
            return ResolveReturn(_mapper.Map<IEnumerable<MentoredPaymentListViewModel>>(obj));
        }

        [HttpGet, Route("id/{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredPaymentListViewModel>> GetById([FromRoute] int id)
        {
            var obj = await _mentoredPayment.GetByIdAsync(id);
            return ResolveReturn(_mapper.Map<MentoredPaymentListViewModel>(obj));
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredPaymentPutViewModel>> Post([FromBody] MentoredPaymentPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<MentoredPutPaymentDTO>(model);

            var result = await _mentoredPayment.CreateOrUpdate(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredPaymentViewModel>> Put(int id, [FromBody] MentoredPaymentPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<MentoredPutPaymentDTO>(model);
            var result = await _mentoredPayment.CreateOrUpdate(obj);
            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}/change-status")]
        public async Task<ActionResult<bool>> Put(int id, [FromBody] SubscriptionStatusEnum status)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _mentoredPayment.ChangeStatusSubscription(status, id);

            return ResolveReturn(result);
        }
        #endregion
    }
}
