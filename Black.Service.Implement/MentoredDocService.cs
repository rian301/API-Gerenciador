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
    public class MentoredDocService : ServiceBaseCRUD<MentoredDoc, Guid>, IMentoredDocService
	{
		private readonly IMentoredDocRepository _mentoredRepository;

		public MentoredDocService(IMentoredDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<MentoredDoc>> GetAllByMentoredIdAsync(int mentoredId) => _mentoredRepository.GetAllByMentoredIdAsync(mentoredId);
		public Task<List<MentoredDoc>> GetAllActives(int customerDependentId) => _mentoredRepository.GetAllActives(customerDependentId);
		public Task<MentoredDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc) => _mentoredRepository.GetDocsActivesbyType(customerDependentId, typedoc);
		public Task<MentoredDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc) => _mentoredRepository.ChangeStatusDoc(docId, mentoredId, typedoc);

	}
}
