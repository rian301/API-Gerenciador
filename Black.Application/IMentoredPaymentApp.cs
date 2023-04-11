using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IMentoredPaymentApp : IAppBaseCRUD<MentoredPayment, int>
    {
        Task<List<MentoredPayment>> GetAllByMentoredIdAsync(int mentoredId);
        Task<bool> CreateOrUpdate(MentoredPutPaymentDTO dto);
        Task<bool> ChangeStatusSubscription(SubscriptionStatusEnum status, int id);
    }
}
