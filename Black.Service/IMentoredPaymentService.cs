using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IMentoredPaymentService : IServiceBaseCRUD<MentoredPayment, int>
    {
        Task<List<MentoredPayment>> GetAllByMentoredIdAsync(int mentoredId);
    }
}
