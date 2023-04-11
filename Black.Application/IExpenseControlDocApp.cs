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
    public interface IExpenseControlDocApp : IAppBaseCRUD<ExpenseControlDoc, Guid>   
	{
		Task<ExpenseControlDoc> UploadDocAsync(int expenseId, TypeDocEnum type, Stream filestream = null, string filename = null);
		Task<List<ExpenseControlDoc>> GetAllByExpenseControlIdAsync(int expenseId);
		Task<List<ExpenseControlDoc>> GetAllActivesAsync(int expenseId);
		Task<BlobFileDTO> DownloadDoc(Guid id);
		Task<ExpenseControlDoc> ChangeStatusDoc(Guid docId, int expenseId, TypeDocEnum typedoc, bool active);
		Task<string> GetUrlDocById(Guid id);
	}
}
