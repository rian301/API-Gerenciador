﻿using AutoMapper;
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
    public class DocumentController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IDocumentApp _app;
        #endregion

        #region Constructors
        public DocumentController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IDocumentApp app, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_VIEW })]
        public async Task<ActionResult<IEnumerable<DocumentViewModel>>> GetAll()
        {
            var obj = await _app.GetAllAsync();
            return ResolveReturn(_mapper.Map<IEnumerable<DocumentViewModel>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_VIEW })]
        public async Task<ActionResult<DocumentViewModel>> Get(int id)
        {
            var obj = await _app.GetByIdAsync(id);
            var objVM = _mapper.Map<DocumentViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_ADD })]
        public async Task<ActionResult<DocumentViewModel>> Post([FromBody] DocumentViewModel model, int customerId)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var obj = _mapper.Map<Document>(model);

            var result = await _app.AddAsync(obj);

            return ResolveReturn(result);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_ADD })]
        public async Task<ActionResult<DocumentViewModel>> Put(int id, [FromBody] DocumentViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var obj = _mapper.Map<Document>(model);
            obj.ChangedAt = System.DateTime.Now;
            obj.SetUserChangeId(_user.Id.Value);

            await _app.UpdateAsync(obj);

            return ResolveReturn(Ok());
        }

        [Permission(Permissions = new string[] { PermissionConst.EXPENSE_CATEGORY_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<DocumentViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _app.DeleteAsync(id);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
