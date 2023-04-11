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
    public interface IMentoredDocApp : IAppBaseCRUD<MentoredDoc, Guid>   
	{
		Task<MentoredDoc> UploadDocAsync(int customerId, int? companyId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<MentoredDoc>> GetAllByMentoredIdAsync(int mentoredId);
		Task<List<MentoredDoc>> GetAllActivesAsync(int customerDependentId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<MentoredDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc, bool active);
	}
}
