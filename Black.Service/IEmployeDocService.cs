using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IEmployeeDocService : IServiceBaseCRUD<EmployeeDoc, Guid>
	{
		Task<List<EmployeeDoc>> GetAllByEmployeeIdAsync(int mentoredId);
		Task<List<EmployeeDoc>> GetAllActives(int customerDependentId);
		Task<EmployeeDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum docType);
		Task<EmployeeDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum docType);
	}
}
