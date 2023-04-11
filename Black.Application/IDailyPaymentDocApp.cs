using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IDailyPaymentDocApp : IAppBaseCRUD<DailyPaymentDoc, Guid>   
	{
		Task<DailyPaymentDoc> UploadDocAsync(int customerId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<DailyPaymentDoc>> GetAllByDailyPaymentIdAsync(int mentoredId);
		Task<List<DailyPaymentDoc>> GetAllActivesAsync(int customerDependentId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<DailyPaymentDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc, bool active);
	}
}
