using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IDailyPaymentDocService : IServiceBaseCRUD<DailyPaymentDoc, Guid>
	{
		Task<List<DailyPaymentDoc>> GetAllByDailyPaymentIdAsync(int mentoredId);
		Task<List<DailyPaymentDoc>> GetAllActives(int customerDependentId);
		Task<DailyPaymentDoc> GetDocsActivesbyType(int customerDependentId, TypeDocEnum typedoc);
		Task<DailyPaymentDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc);
	}
}
