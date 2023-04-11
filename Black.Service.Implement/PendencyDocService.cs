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
    public class PendencyDocService : ServiceBaseCRUD<PendencyDoc, Guid>, IPendencyDocService
	{
		private readonly IPendencyDocRepository _pendencyRepository;

		public PendencyDocService(IPendencyDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_pendencyRepository = repository;
		}

		public Task<List<PendencyDoc>> GetAllByPendencyIdAsync(int pendencyId) => _pendencyRepository.GetAllByPendencyIdAsync(pendencyId);
		public Task<List<PendencyDoc>> GetAllActives(int customerDependentId) => _pendencyRepository.GetAllActives(customerDependentId);
		public Task<PendencyDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc) => _pendencyRepository.GetDocsActivesbyType(customerDependentId, typedoc);
		public Task<PendencyDoc> ChangeStatusDoc(Guid docId, int pendencyId, TypeDocEnum typedoc) => _pendencyRepository.ChangeStatusDoc(docId, pendencyId, typedoc);

	}
}
