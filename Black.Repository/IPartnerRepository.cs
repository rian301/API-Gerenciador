using Black.Domain.Models;
using Black.Repository.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IPartnerRepository : IRepositoryBaseCRUD<Partner, int>
    {
        Task<int> QuantityPartners();
        Task<List<Partner>> GetByMentoredId(int mentoredId);
        Task<Partner> GetByMentoredPartnerId(int mentoredId);
        Task<Partner> GetByMentoredAndPartnerId(int id, int partnerId);
    }
}
