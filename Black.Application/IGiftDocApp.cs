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
    public interface IGiftDocApp : IAppBaseCRUD<GiftDoc, Guid>   
	{
		Task<GiftDoc> UploadDocAsync(int expenseId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<GiftDoc>> GetAllByGiftIdAsync(int expenseId);
		Task<List<GiftDoc>> GetAllActivesAsync(int expenseId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<GiftDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc, bool active);
		Task<string> GetUrlDocById(Guid id);
	}
}
