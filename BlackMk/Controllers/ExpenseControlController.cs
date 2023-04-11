using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class ExpenseControlController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IExpenseControlApp _app;
        private readonly IExpenseControlDocApp _appDoc;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructors
        public ExpenseControlController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IExpenseControlApp app, IExpenseControlDocApp appDoc, IConfiguration configuration, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
            _appDoc = appDoc;
            _configuration = configuration;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        public async Task<ActionResult<IEnumerable<ExpenseControlViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<ExpenseControlViewModel>>(obj));
        }

        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        [HttpGet("period")]
        public async Task<ActionResult<List<ExpenseControlViewModel>>> GetAllDependentByCustomer(DateTime datInit, DateTime datEnd)
        {
            var expenses = await _app.GetByPeriod(datInit, datEnd);

            var expensesMap = _mapper.Map<List<ExpenseControlViewModel>>(expenses);

            foreach (var item in expensesMap)
            {
                if (item?.Id > 0 && !string.IsNullOrEmpty(item.Extension))
                {
                    item.UrlImage = _configuration["Integration:AzureStorageBlob:Url-Expense-Doc"] + $"{item.Id}" + $"{ item.Extension}";

                }
            }

            return ResolveReturn(expensesMap);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        public async Task<ActionResult<ExpenseControlViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<ExpenseControlViewModel>(obj);

            if (objVM?.Id > 0 && !string.IsNullOrEmpty(objVM.Extension))
            {
                objVM.UrlImage = _configuration["Integration:AzureStorageBlob:Url-Expense-Doc"] + $"{objVM.Id}" + $"{ objVM.Extension}";

            }

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_ADD })]
        public async Task<ActionResult<ExpenseControlViewModel>> Post([FromBody] ExpenseControlViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<ExpenseControl>(model);

            var result = await _app.AddExpense(obj);

            ExpenseControlDoc customerDoc = null;

            if (model.Deleted == null)
                model.Deleted = DeletedEnum.No;

            if (model.ImageUpload != null && result != null)
            {
                var img = ImageHelper.ConvertBase64ToImage(model.ImageUpload);
                using var streamfile = new MemoryStream(img.RawData);
                customerDoc = await _appDoc.UploadDocAsync(result.Id, TypeDocEnum.Receipt, streamfile, model.FileName);
            }

            return ResolveReturn(_mapper.Map<ExpenseControlViewModel>(result));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_ADD })]
        public async Task<ActionResult<ExpenseControlPutViewModel>> Put(int id, [FromBody] ExpenseControlPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            if (model.Deleted == null)
                model.Deleted = DeletedEnum.No;

            model.Id = id;
            var obj = _mapper.Map<ExpenseControl>(model);
            obj.ChangedAt = DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_REMOVE })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<ExpenseControlViewModel>>> Remove([FromRoute] int id)
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
