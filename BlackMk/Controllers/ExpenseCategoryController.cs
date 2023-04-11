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
    public class ExpenseCategoryController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IExpenseCategoryApp _app;
        #endregion

        #region Constructors
        public ExpenseCategoryController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IExpenseCategoryApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_VIEW })]
        public async Task<ActionResult<IEnumerable<ExpenseCategoryViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<ExpenseCategoryViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_VIEW })]
        public async Task<ActionResult<ExpenseCategoryViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<ExpenseCategoryViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_ADD })]
        public async Task<ActionResult<ExpenseCategoryViewModel>> Post([FromBody] ExpenseCategoryViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<ExpenseCategory>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_ADD })]
        public async Task<ActionResult<ExpenseCategoryViewModel>> Put(int id, [FromBody] ExpenseCategoryViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<ExpenseCategory>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<ExpenseCategoryViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
