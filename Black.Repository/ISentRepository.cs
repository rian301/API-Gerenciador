using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ISentRepository : IRepositoryBaseCRUD<Sent, int>
    {
        Task<bool> GetByAwardAsync(int awardId, int customerId, int? ignoreId);
        Task<bool> GetMentoredByAwardAsync(int awardId, int mentoredId, int? ignoreId);
        Task<IQueryable<Sent>> GetAllPagination(QuerySentDTO filter, PaginationDTO pagination);
    }
}
