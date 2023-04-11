﻿using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using Black.Service.Integration.AzureStorage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class MentoredDocApp : AppBaseCRUD<MentoredDoc, Guid>, IMentoredDocApp
    {
        #region Properties
        private readonly IMentoredDocService _mentoredDocService;
        private readonly IAzureStorageService _azureStorageService;
        private readonly IConfiguration _configuration;
        #endregion

        public MentoredDocApp(IMentoredDocService service, INotificationHandler<DomainNotification> notification, IUser user, IUnitOfWork uow,
            IAzureStorageService azureStorageService, IConfiguration configuration, IMentoredDocService MentoredDocService) : base(service, notification, user, uow)
        {
            _azureStorageService = azureStorageService;
            _configuration = configuration;
            _mentoredDocService = MentoredDocService;
        }

        public async Task<MentoredDoc> UploadDocAsync(int mentoredId, int? companyId, TypeDocEnum type, Stream filestream = null, string filename = null)
        {
            string extension = string.Empty;

            if (filestream == null || string.IsNullOrEmpty(filename))
            {
                _notification.Handle(new DomainNotification("TypeInvalid", "Arquivo não informado"));
                return null;
            }

            // Valida o arquivo
            IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".pdf" };
            var ext = filename.Substring(filename.LastIndexOf('.'));
            extension = ext.ToLower();

            int MaxContentLength = 1024 * 1024 * 20;

            if (!AllowedFileExtensions.Contains(extension))
            {
                _notification.Handle(new DomainNotification("FileExtensionInvalid", string.Format("Permitido apenas arquivos no formatos .jpg .png e .pdf")));
                return null;
            }

            if (filestream.Length > MaxContentLength)
            {
                _notification.Handle(new DomainNotification("FileExtensionInvalid", string.Format("Arquivo com máximo de 20 MB")));
                return null;
            }

            // Se já existir um doc do mesmo type, inativa para inserir o novo
            //var mentoredDoc = await _mentoredDocService.GetDocsActivesbyType(mentoredId, type);

            //Atualiza registros antigos para inativo
            //if (mentoredDoc != null)
            //{
            //    mentoredDoc.SetActive(false);
            //    await UpdateAsync(mentoredDoc);
            //}

            string container = _configuration["Integration:AzureStorageBlob:MentoredDoc-Container"];
            // Cria um novo doc
            var doc = new MentoredDoc(filename, extension, type, container, mentoredId, companyId);

            // Upload no storage
            if (!doc.IsValid())
            {
                _notification.Handle(doc.ValidationResult.Errors);
                return null;
            }

            var uploadResult = await _azureStorageService.UploadFile(container, filestream, doc.Id.ToString() + extension);
            if (uploadResult)
            {
                await base.AddAsync(doc);
                return doc;
            }
            else
            {
                _notification.Handle(new DomainNotification("FileExtensionInvalid", "Não foi possível realizar o upload do arquivo no storage"));
                return null;
            }
        }

        public async Task<MentoredDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc, bool active)
        {
            var mentoredDoc = await _mentoredDocService.ChangeStatusDoc(docId, mentoredId, typedoc);

            if (mentoredDoc != null)
            {
                mentoredDoc.SetActive(active);
                await UpdateAsync(mentoredDoc);
                return mentoredDoc;
            }
            else
            {
                _notification.Handle(new DomainNotification("FileNotFound", "Não foi possível alterar o status do arquivo."));
                return null;
            }
        }

        public Task<List<MentoredDoc>> GetAllByMentoredIdAsync(int mentoredId) => _mentoredDocService.GetAllByMentoredIdAsync(mentoredId);

        public Task<List<MentoredDoc>> GetAllActivesAsync(int mentoredDependentId) => _mentoredDocService.GetAllActives(mentoredDependentId);

        public async Task<BlobFileDTO> DownloadDoc(Guid id)
        {
            var mentoredDoc = await GetByIdAsync(id);

            if (mentoredDoc == null)
            {
                _notification.Handle(new DomainNotification("DocumentNotFound", "Documento não encontrado"));
                return null;
            }

            string container = _configuration["Integration:AzureStorageBlob:MentoredDoc-Container"];
            var file = await _azureStorageService.DownloadFile(container, $"{mentoredDoc.Id}{mentoredDoc.Extension}");
            return file;
        }
    }
}
