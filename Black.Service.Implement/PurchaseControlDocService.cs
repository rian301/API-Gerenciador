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
    public class PurchaseControlDocService : ServiceBaseCRUD<PurchaseControlDoc, Guid>, IPurchaseControlDocService
	{
		private readonly IPurchaseControlDocRepository _mentoredRepository;

		public PurchaseControlDocService(IPurchaseControlDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<PurchaseControlDoc>> GetAllByPurchaseControlIdAsync(int mentoredId) => _mentoredRepository.GetAllByPurchaseControlIdAsync(mentoredId);
		public Task<List<PurchaseControlDoc>> GetAllActives(int customerDependentId) => _mentoredRepository.GetAllActives(customerDependentId);
		public Task<PurchaseControlDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc) => _mentoredRepository.GetDocsActivesbyType(customerDependentId, typedoc);
		public Task<PurchaseControlDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc) => _mentoredRepository.ChangeStatusDoc(docId, mentoredId, typedoc);

	}
}
