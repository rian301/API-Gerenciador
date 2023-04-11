using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPendencyService : IServiceBaseCRUD<Pendency, int>
    {
        //IEnumerable<Pendency> GetAllActiveInCheckout();
        //IEnumerable<Pendency> GetAllActiveInCheckoutOffline();
        Task<Pendency> GetByDescriptionAsync(string description);
    }
}
