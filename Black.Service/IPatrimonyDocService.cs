using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPatrimonyDocService : IServiceBaseCRUD<PatrimonyDoc, Guid>
	{
		Task<List<PatrimonyDoc>> GetAllByPatrimonyIdAsync(int mentoredId);
		Task<List<PatrimonyDoc>> GetAllActives(int customerDependentId);
		Task<PatrimonyDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
		Task<PatrimonyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
	}
}
