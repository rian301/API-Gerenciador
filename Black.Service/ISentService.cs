using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ISentService : IServiceBaseCRUD<Sent, int>
    {
        Task<bool> GetByAwardAsync(int awardId, int customerId, int? ignoreId);
        Task<bool> GetMentoredByAwardAsync(int awardId, int mentoredId, int? ignoreId);
        Task<IQueryable<Sent>> GetAllPagination(QuerySentDTO filter, PaginationDTO pagination);
    }
}
