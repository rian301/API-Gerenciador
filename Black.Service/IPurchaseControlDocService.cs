using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPurchaseControlDocService : IServiceBaseCRUD<PurchaseControlDoc, Guid>
	{
		Task<List<PurchaseControlDoc>> GetAllByPurchaseControlIdAsync(int mentoredId);
		Task<List<PurchaseControlDoc>> GetAllActives(int customerDependentId);
		Task<PurchaseControlDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
		Task<PurchaseControlDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
	}
}
