using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IMentoredPaymentRepository : IRepositoryBaseCRUD<MentoredPayment, int>
    {
        Task<List<MentoredPayment>> GetAllByMentoredIdAsync(int mentoredId);
    }
}
