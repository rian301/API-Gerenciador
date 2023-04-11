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
    [Route("purchasecontrol/{purchaseId}/docs")]
    public class PurchaseControlDocDocsController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IPurchaseControlDocApp _purchaseDocApp;
        #endregion

        #region Constructors
        public PurchaseControlDocDocsController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IPurchaseControlDocApp customerDocApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _purchaseDocApp = customerDocApp;
        }

        #endregion

        #region Actions
        /// <summary>
        /// Retorna os documentos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        public async Task<ActionResult<IEnumerable<PurchaseControlDocViewModel>>> GetDocs(int purchaseId)
        {
            var obj = await _purchaseDocApp.GetAllByPurchaseControlIdAsync(purchaseId);
            var objVM = _mapper.Map<IEnumerable<PurchaseControlDocViewModel>>(obj);

            return ResolveReturn(objVM);
        }

        /// <summary>
        /// Adiciona um novo documento
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        public async Task<ActionResult> PostDocs([FromRoute] int purchaseId, [FromForm] List<IFormFile> files, [FromForm] TypeDocEnum type)
        {
            if (files.Count() <= 0)
                return BadRequestRegraNegocio("Informe um arquivo válido");

            PurchaseControlDoc customerDoc = null;

            if (files.Count() > 0)
            {
                foreach (var file in files)
                {
                    using var streamfile = new MemoryStream();
                    await file.CopyToAsync(streamfile);
                    customerDoc = await _purchaseDocApp.UploadDocAsync(purchaseId, type, streamfile, file.FileName);
                }
            }

            return ResolveReturn(_mapper.Map<PurchaseControlDocViewModel>(customerDoc));
        }

        /// <summary>
        /// Adiciona um novo documento
        /// </summary>
        /// <returns></returns>
        [HttpPost, Route("change-status")]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        public async Task<ActionResult> ChangeStatusDoc([FromBody] DocChangeStatusViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var doc = await _purchaseDocApp.ChangeStatusDoc(model.DocId, model.MentoredId, model.Type, model.Active);

            return ResolveReturn(_mapper.Map<PurchaseControlDocViewModel>(doc));
        }

        /// <summary>
        /// Download do documento
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("{idDoc:guid}")]
        [Permission(Permissions = new string[] { PermissionConst.PURCHASE_CONTROL_ADD })]
        public async Task<ActionResult<IEnumerable<PurchaseControlDocViewModel>>> GetDocs([FromRoute] Guid idDoc)
        {
            var file = await _purchaseDocApp.DownloadDoc(idDoc);

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
