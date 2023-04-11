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
    public interface IEmployeeDocApp : IAppBaseCRUD<EmployeeDoc, Guid>   
	{
		Task<EmployeeDoc> UploadDocAsync(int expenseId, TypeDocEnum typeDoc, Stream filestream = null, string filename = null);
		Task<List<EmployeeDoc>> GetAllByEmployeeIdAsync(int expenseId);
		Task<List<EmployeeDoc>> GetAllActivesAsync(int expenseId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<EmployeeDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typeDoc, bool active);
	}
}
