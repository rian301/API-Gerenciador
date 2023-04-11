using Black.Application.Base;
using Black.Domain.Enums;
using Black.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface ISubscriptionApp : IAppBaseCRUD<Subscription, int>
    {
        Task<Subscription> GetByMentoredAsync(int mentoredId);
        Task<List<Subscription>> GetAllByMentoredAsync(int mentoredId, int? partnerId);
        Task<List<Subscription>> GetAllByProduct(int productId);
        Task<List<Subscription>> GetAllByDateAsync(DateTime? date);
    }
}
