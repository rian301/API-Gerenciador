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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class PurchaseControlController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IPurchaseControlApp _app;
        #endregion

        #region Constructors
        public PurchaseControlController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IPurchaseControlApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_VIEW })]
        //public async Task<ActionResult<IEnumerable<PurchaseControlListViewModel>>> GetAll()
        public async Task<ActionResult<IEnumerable<PaginationResponseDTO<PurchaseControlListViewModel>>>> GetAll([FromQuery] PurchaseControlFilterDto query)
        {
            var obj = await _app.GetAllPagination(query);
            var count = obj.Count();

            var objVM = _mapper.Map<List<PurchaseControlListViewModel>>(obj);
            var ret = new PaginationResponseDTO<PurchaseControlListViewModel>(count, objVM);

            return ResolveReturn(ret);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_VIEW })]
        public async Task<ActionResult<PurchaseControlListViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<PurchaseControlListViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        public async Task<ActionResult<PurchaseControlViewModel>> Post([FromBody] PurchaseControlViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<PurchaseControl>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        public async Task<ActionResult<PurchaseControlViewModel>> Put(int id, [FromBody] PurchaseControlViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<PurchaseControl>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<PurchaseControlListViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
