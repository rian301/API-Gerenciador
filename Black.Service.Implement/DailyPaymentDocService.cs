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
    public class DailyPaymentDocService : ServiceBaseCRUD<DailyPaymentDoc, Guid>, IDailyPaymentDocService
	{
		private readonly IDailyPaymentDocRepository _mentoredRepository;

		public DailyPaymentDocService(IDailyPaymentDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<DailyPaymentDoc>> GetAllByDailyPaymentIdAsync(int mentoredId) => _mentoredRepository.GetAllByDailyPaymentIdAsync(mentoredId);
		public Task<List<DailyPaymentDoc>> GetAllActives(int customerDependentId) => _mentoredRepository.GetAllActives(customerDependentId);
		public Task<DailyPaymentDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc) => _mentoredRepository.GetDocsActivesbyType(customerDependentId, typedoc);
		public Task<DailyPaymentDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc) => _mentoredRepository.ChangeStatusDoc(docId, mentoredId, typedoc);

	}
}
