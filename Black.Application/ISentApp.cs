using Black.Application.Base;
using Black.Domain.DTO;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ISentApp : IAppBaseCRUD<Sent, int>
    {
        Task<Sent> CreateOrUpdateAsync(Sent model);
        Task<IQueryable<Sent>> GetAllPagination(QuerySentDTO query);
    }
}
