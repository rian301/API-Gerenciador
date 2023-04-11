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
    public class EmployeeDocService : ServiceBaseCRUD<EmployeeDoc, Guid>, IEmployeeDocService
	{
		private readonly IEmployeeDocRepository _mentoredRepository;

		public EmployeeDocService(IEmployeeDocRepository repository, INotificationHandler<DomainNotification> notification)
			: base(repository, notification)
		{
			_mentoredRepository = repository;
		}

		public Task<List<EmployeeDoc>> GetAllByEmployeeIdAsync(int mentoredId) => _mentoredRepository.GetAllByEmployeeIdAsync(mentoredId);
		public Task<List<EmployeeDoc>> GetAllActives(int customerDependentId) => _mentoredRepository.GetAllActives(customerDependentId);
		public Task<EmployeeDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typeDoc) => _mentoredRepository.GetDocsActivesbyType(customerDependentId, typeDoc);
		public Task<EmployeeDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typeDoc) => _mentoredRepository.ChangeStatusDoc(docId, mentoredId, typeDoc);

	}
}
