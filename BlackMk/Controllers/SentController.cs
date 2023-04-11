using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class SentController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ISentApp _app;
        #endregion

        #region Constructors
        public SentController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   ISentApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.SENT_VIEW })]
        public async Task<ActionResult<IEnumerable<PaginationResponseDTO<SentViewModel>>>> GetAll([FromQuery] QuerySentDTO filter)
        {
            var query = await _app.GetAllPagination(filter);

            var result = _mapper.Map<List<SentViewModel>>(query);

            var count = result.Count();

            //var objVM = _mapper.Map<List<SentViewModel>>(obj);
            var ret = new PaginationResponseDTO<SentViewModel>(count, result);

            return ResolveReturn(ret);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.SENT_VIEW })]
        public async Task<ActionResult<SentViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<SentViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.SENT_ADD })]
        public async Task<ActionResult<SentViewModel>> Post([FromBody] SentViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Sent>(model);

            var result = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<SentViewModel>(result));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.SENT_ADD })]
        public async Task<ActionResult<SentViewModel>> Put(int id, [FromBody] SentViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Sent>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.SENT_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<SentViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
