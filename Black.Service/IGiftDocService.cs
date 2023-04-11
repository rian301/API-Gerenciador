using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IGiftDocService : IServiceBaseCRUD<GiftDoc, Guid>
	{
		Task<List<GiftDoc>> GetAllByGiftIdAsync(int mentoredId);
		Task<List<GiftDoc>> GetAllActives(int customerDependentId);
		Task<GiftDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum docType);
		Task<GiftDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum docType);
	}
}
