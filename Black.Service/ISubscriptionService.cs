using Black.Domain.Models;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface ISubscriptionService : IServiceBaseCRUD<Subscription, int>
    {
        Task<Subscription> GetByMentoredAsync(int mentoredId);
        Task<List<Subscription>> GetAllByMentoredAsync(int mentoredId, int? partnerId);
        Task<List<Subscription>> GetAllByProduct(int productId);
        Task<List<Subscription>> GetAllByDateAsync(DateTime? date);
    }
}
