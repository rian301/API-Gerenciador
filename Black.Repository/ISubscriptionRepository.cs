using Black.Domain.Models;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface ISubscriptionRepository : IRepositoryBaseCRUD<Subscription, int>
    {
        Task<Subscription> GetByMentoredAsync(int mentoredId);
        Task<List<Subscription>> GetAllByMentoredAsync(int mentoredId, int? partnerId);
        Task<List<Subscription>> GetAllByProduct(int productId);
        Task<List<Subscription>> GetAllByDateAsync(DateTime? date);

    }
}
