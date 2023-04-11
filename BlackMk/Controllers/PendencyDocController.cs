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
    [Route("pendency/{pendencyId}/docs")]
    public class PendencyDocDocsController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IPendencyDocApp _pendencyDocApp;
        #endregion

        #region Constructors
        public PendencyDocDocsController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IPendencyDocApp customerDocApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _pendencyDocApp = customerDocApp;
        }

        #endregion

        #region Actions
        /// <summary>
        /// Retorna os documentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_ADD })]
        public async Task<ActionResult<IEnumerable<PendencyDocViewModel>>> GetDocs(int pendencyId)
        {
            var obj = await _pendencyDocApp.GetAllByPendencyIdAsync(pendencyId);
            var objVM = _mapper.Map<IEnumerable<PendencyDocViewModel>>(obj);

            return ResolveReturn(objVM);
        }

        /// <summary>
        /// Adiciona um novo documento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_ADD })]
        public async Task<ActionResult> PostDocs([FromRoute] int pendencyId, [FromForm] List<IFormFile> files, [FromForm] TypeDocEnum type)
        {
            if (files.Count() <= 0)
                return BadRequestRegraNegocio("Informe um arquivo válido");

            PendencyDoc customerDoc = null;

            if (files.Count() > 0)
            {
                foreach (var file in files)
                {
                    using var streamfile = new MemoryStream();
                    await file.CopyToAsync(streamfile);
                    customerDoc = await _pendencyDocApp.UploadDocAsync(pendencyId, type, streamfile, file.FileName);
                }
            }

            return ResolveReturn(_mapper.Map<PendencyDocViewModel>(customerDoc));
        }

        /// <summary>
        /// Adiciona um novo documento
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("change-status")]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_ADD })]
        public async Task<ActionResult> ChangeStatusDoc([FromBody] DocChangeStatusViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var doc = await _pendencyDocApp.ChangeStatusDoc(model.DocId, model.MentoredId, model.Type, model.Active);

            return ResolveReturn(_mapper.Map<PendencyDocViewModel>(doc));
        }

        /// <summary>
        /// Download do documento
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{idDoc:guid}")]
        [Permission(Permissions = new string[] { PermissionConst.DAILY_PAYMENT_ADD })]
        public async Task<ActionResult<IEnumerable<PendencyDocViewModel>>> GetDocs([FromRoute] Guid idDoc)
        {
            var file = await _pendencyDocApp.DownloadDoc(idDoc);

            if (file == null || _notification.HasNotifications())
                return ResolveReturn(file);

            using var streamfile = new MemoryStream();
            await file.Content.CopyToAsync(streamfile);

            return new FileContentResult(streamfile.ToArray(), file.ContentType)
            {
                FileDownloadName = file.Filename
            };
        }

        #endregion
    }
}
