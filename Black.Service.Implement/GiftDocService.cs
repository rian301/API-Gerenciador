using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class GiftDocService : ServiceBaseCRUD<GiftDoc, Guid>, IGiftDocService
	{
		private readonly IGiftDocRepository _mentoredRepository;

		public GiftDocService(IGiftDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<GiftDoc>> GetAllByGiftIdAsync(int mentoredId) => _mentoredRepository.GetAllByGiftIdAsync(mentoredId);
		public Task<List<GiftDoc>> GetAllActives(int customerDependentId) => _mentoredRepository.GetAllActives(customerDependentId);
		public Task<GiftDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typeDoc) => _mentoredRepository.GetDocsActivesbyType(customerDependentId, typeDoc);
		public Task<GiftDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typeDoc) => _mentoredRepository.ChangeStatusDoc(docId, mentoredId, typeDoc);

	}
}
