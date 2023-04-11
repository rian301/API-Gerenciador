using Black.Application.Base;
using Black.Domain.Enums;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IPendencyApp : IAppBaseCRUD<Pendency, int>
    {
        //IEnumerable<Pendency> GetAllActiveInCheckout();
        //IEnumerable<Pendency> GetAllActiveInCheckoutOffline();
        Task<Pendency> CreateOrUpdateAsync(Pendency model);
        Task<bool> StatusChangeAsync(int id, PendencyStatusEnum status);
    }
}
