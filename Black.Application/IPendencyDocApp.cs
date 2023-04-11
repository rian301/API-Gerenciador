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
    public interface IPendencyDocApp : IAppBaseCRUD<PendencyDoc, Guid>   
	{
		Task<PendencyDoc> UploadDocAsync(int customerId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<PendencyDoc>> GetAllByPendencyIdAsync(int mentoredId);
		Task<List<PendencyDoc>> GetAllActivesAsync(int customerDependentId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<PendencyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc, bool active);
	}
}
