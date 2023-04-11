using Black.Domain.Models;
using Black.Service.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IPartnerService : IServiceBaseCRUD<Partner, int>
    {
        Task<int> QuantityPartners();
        Task<List<Partner>> GetByMentoredId(int mentoredId);
        Task<Partner> GetByMentoredPartnerId(int mentoredId);
        Task<Partner> GetByMentoredAndPartnerId(int id, int partnerId);
    }
}
