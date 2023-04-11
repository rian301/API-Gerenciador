using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPendencyDocService : IServiceBaseCRUD<PendencyDoc, Guid>
	{
		Task<List<PendencyDoc>> GetAllByPendencyIdAsync(int mentoredId);
		Task<List<PendencyDoc>> GetAllActives(int customerDependentId);
		Task<PendencyDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
		Task<PendencyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
	}
}
