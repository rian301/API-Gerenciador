using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class DailyPaymentController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IDailyPaymentApp _app;
        #endregion

        #region Constructors
        public DailyPaymentController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IDailyPaymentApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_VIEW })]
        public async Task<ActionResult<IEnumerable<PaginationResponseDTO<DailyPaymentViewModel>>>> GetAll([FromQuery] QueryDailyPaymentDTO query)
        {

            var obj = await _app.GetAllPagination(query);
            var count = obj.Count();

            var objVM = _mapper.Map<List<DailyPaymentViewModel>>(obj);
            var ret = new PaginationResponseDTO<DailyPaymentViewModel>(count, objVM);

            return ResolveReturn(ret);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_VIEW })]
        public async Task<ActionResult<DailyPaymentViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<DailyPaymentViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_ADD })]
        public async Task<ActionResult<DailyPaymentPutViewModel>> Post([FromBody] DailyPaymentPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            if (model.Deleted == null)
                model.Deleted = DeletedEnum.No;

            var obj = _mapper.Map<DailyPayment>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(_mapper.Map<DailyPaymentPutViewModel>(obj));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_ADD })]
        public async Task<ActionResult<DailyPaymentPutViewModel>> Put(int id, [FromBody] DailyPaymentPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            if (model.Deleted == null)
                model.Deleted = DeletedEnum.No;

            model.Id = id;
            var obj = _mapper.Map<DailyPayment>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            var result = await _app.UpdateAsync(obj);

            return ResolveReturn(result);
        }

        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_REMOVE })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<DailyPaymentViewModel>>> Remove([FromRoute] int id)
        {
            var obj = await _app.GetByIdAsync(id);
            obj.SetUserChangeId(_user.Id.Value);
            var ret = obj.SetDeleted();
            await _app.UpdateAsync(obj);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
