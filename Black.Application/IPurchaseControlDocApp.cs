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
    public interface IPurchaseControlDocApp : IAppBaseCRUD<PurchaseControlDoc, Guid>   
	{
		Task<PurchaseControlDoc> UploadDocAsync(int customerId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<PurchaseControlDoc>> GetAllByPurchaseControlIdAsync(int mentoredId);
		Task<List<PurchaseControlDoc>> GetAllActivesAsync(int customerDependentId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<PurchaseControlDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc, bool active);
	}
}
