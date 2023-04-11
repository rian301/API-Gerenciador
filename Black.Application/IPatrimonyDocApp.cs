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
    public interface IPatrimonyDocApp : IAppBaseCRUD<PatrimonyDoc, Guid>   
	{
		Task<PatrimonyDoc> UploadDocAsync(int customerId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<PatrimonyDoc>> GetAllByPatrimonyIdAsync(int mentoredId);
		Task<List<PatrimonyDoc>> GetAllActivesAsync(int customerDependentId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<PatrimonyDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum typedoc, bool active);
	}
}
