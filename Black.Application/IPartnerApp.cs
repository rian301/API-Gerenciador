using Black.Application.Base;
using Black.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IPartnerApp : IAppBaseCRUD<Partner, int>
    {
        Task<int> QuantityPartners();
        Task<List<Partner>> GetByMentoredId(int mentoredId);
        Task<Partner> GetByMentoredPartnerId(int mentoredId);
        Task<Partner> GetByMentoredAndPartnerId(int partnerId, int mentoredId);
    }
}
