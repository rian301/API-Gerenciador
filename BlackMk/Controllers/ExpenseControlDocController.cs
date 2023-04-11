using AutoMapper;
using Black.API.Admin.ViewModels;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace Black.API.Admin.Controllers
{
    [Route("expensecontrol/{expensecontrolId}/docs")]
    public class ExpenseControlDocDocsController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IExpenseControlDocApp _expenseDocApp;
        #endregion

        #region Constructors
        public ExpenseControlDocDocsController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IExpenseControlDocApp expenseDocApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _expenseDocApp = expenseDocApp;
        }

        #endregion

        #region Actions
        /// <summary>
        /// Retorna os documentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        public async Task<ActionResult<IEnumerable<ExpenseControlDocViewModel>>> GetDocs(int expensecontrolId)
        {
            var obj = await _expenseDocApp.GetAllByExpenseControlIdAsync(expensecontrolId);
            var objVM = _mapper.Map<IEnumerable<ExpenseControlDocViewModel>>(obj);

            return ResolveReturn(objVM);
        }

        /// <summary>
        /// Adiciona um novo documento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        public async Task<ActionResult> PostDocs([FromRoute] int expensecontrolId, [FromForm] List<IFormFile> files, [FromForm] TypeDocEnum type)
        {
            if (files.Count() <= 0)
                return BadRequestRegraNegocio("Informe um arquivo válido");

            ExpenseControlDoc customerDoc = null;

            if (files.Count() > 0)
            {
                foreach (var file in files)
                {
                    using var streamfile = new MemoryStream();
                    await file.CopyToAsync(streamfile);
                    customerDoc = await _expenseDocApp.UploadDocAsync(expensecontrolId, type, streamfile, file.FileName);
                }
            }

            return ResolveReturn(_mapper.Map<ExpenseControlDocViewModel>(customerDoc));
        }

        /// <summary>
        /// Adiciona um novo documento
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("change-status")]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_ADD })]
        public async Task<ActionResult> ChangeStatusDoc([FromBody] DocChangeStatusViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var doc = await _expenseDocApp.ChangeStatusDoc(model.DocId, model.MentoredId, model.Type, model.Active);

            return ResolveReturn(_mapper.Map<ExpenseControlDocViewModel>(doc));
        }

        /// <summary>
        /// Download do documento
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{idDoc:guid}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        public async Task<ActionResult<IEnumerable<ExpenseControlDocViewModel>>> GetDocs([FromRoute] Guid idDoc)
        {
            var file = await _expenseDocApp.DownloadDoc(idDoc);

            if (file == null)
                return ResolveReturn(file);

            using var streamfile = new MemoryStream();
            await file.Content.CopyToAsync(streamfile);

            return new FileContentResult(streamfile.ToArray(), file.ContentType)
            {
                FileDownloadName = file.Filename
            };
        }


        /// <summary>
        /// Download do documento
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("find/{idDoc:guid}")]
        [Permission(Permissions = new string[] { PermissionConst.EXPANSE_CONTROL_VIEW })]
        public async Task<ActionResult<string>> GetUrlDocById([FromRoute] Guid idDoc)
        {
            var url = await _expenseDocApp.GetUrlDocById(idDoc);
            return url;
        }

        #endregion
    }
}
