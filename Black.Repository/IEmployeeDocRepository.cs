using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IEmployeeDocRepository : IRepositoryBaseCRUD<EmployeeDoc, Guid>
    {
        Task<EmployeeDoc> GetByFileNameAsync(string filename);
        Task<List<EmployeeDoc>> GetAllByEmployeeIdAsync(int mentoredId);
        Task<List<EmployeeDoc>> GetAllActives(int employeeId);
        Task<EmployeeDoc> GetDocsActivesbyType(int employeeId, TypeDocEnum doc);
        Task<EmployeeDoc> ChangeStatusDoc(Guid docId, int mentoredId, TypeDocEnum doc);
    }
}
