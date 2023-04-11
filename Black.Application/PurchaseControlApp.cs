using Black.Application.Base;
using Black.Domain.DTO;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IPurchaseControlApp : IAppBaseCRUD<PurchaseControl, int>
    {
        Task<IQueryable<PurchaseControl>> GetAllPagination(PurchaseControlFilterDto dto);
    }
}
