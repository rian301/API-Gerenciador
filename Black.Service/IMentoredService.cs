using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IMentoredService : IServiceBaseCRUD<Mentored, int>
    {
        Task<List<Mentored>> GetAllMentoredAndCompany();
        Task<Mentored> GetMentoredAndCompany(int id);
        Task<List<Mentored>> GetAllMentoredAndCompaniesAsync(DateTime datInit, DateTime datEnd);
        Task<List<MentoredQueryResult>> GetAllMentoredAndCompaniesPaymentAsync(DateTime datInit, DateTime datEnd);
        Task<GetMentoredAndPartnerQueryResult> GetMentoredAndPartner(int id);
        Task<List<Mentored>> GetAllByBirthdayMonth(string month);
    }
}
