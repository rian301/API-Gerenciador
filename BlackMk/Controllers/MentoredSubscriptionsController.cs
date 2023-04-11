using AutoMapper;
using Black.API.Admin.ViewModels;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Application.DTO;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.API.Admin.Controllers
{
    [Route("mentoreds/{id:int}/subscriptions")]
    public class MentoredSubscriptionsController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ISubscriptionApp _subscriptionApp;
        #endregion

        #region Constructors
        public MentoredSubscriptionsController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                                ISubscriptionApp subscriptionApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _subscriptionApp = subscriptionApp;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Retorna a assinatura com as faturas do associado
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<List<SubscriptionViewModel>>> Get(int id)
        {
            var sub = await _subscriptionApp.GetAllByMentoredAsync(id, null);
            var subVM = _mapper.Map<List<SubscriptionViewModel>>(sub);

            return ResolveReturn(subVM);
        }

        /// <summary>
        /// Retorna a assinatura com as faturas do associado
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("partner")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<List<SubscriptionViewModel>>> GetSubscriptionByMentoredAndPartner(int id, int? partnerId)
        {
            var sub = await _subscriptionApp.GetAllByMentoredAsync(id, partnerId);
            var subVM = _mapper.Map<List<SubscriptionViewModel>>(sub);

            return ResolveReturn(subVM);
        }

        /// <summary>
        /// Retorna a assinatura com as faturas do associado por id
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{subscriptionId:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<SubscriptionViewModel>> GetById(int subscriptionId)
        {
            var sub = await _subscriptionApp.GetByIdAsync(subscriptionId);
            var subVM = _mapper.Map<SubscriptionViewModel>(sub);

            return ResolveReturn(subVM);
        }

        /// <summary>
        /// Nova assinatura
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<SubscriptionPutViewModel>> Post(int id, [FromBody] SubscriptionPutViewModel vm)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var model = _mapper.Map<Subscription>(vm);

            var result = await _subscriptionApp.AddAsync(model);

            //var result = await _checkoutApp.NewMentoredSubscriptionAsync(id, model);            
            return ResolveReturn(result);
        }

        [HttpPut, Route("{subscriptionId:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<SubscriptionPutViewModel>> Put(int subscriptionId, [FromBody] SubscriptionPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = subscriptionId;
            var obj = _mapper.Map<Subscription>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            var result = await _subscriptionApp.UpdateAsync(obj);

            return ResolveReturn(result);
        }
        #endregion
    }
}
