using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IMentoredRepository : IRepositoryBaseCRUD<Mentored, int>
    {
        Task<Mentored> GetMentoredAndCompany(int id);
        Task<List<Mentored>> GetAllMentoredAndCompany();
        Task<List<Mentored>> GetAllMentoredAndCompaniesAsync(DateTime datInit, DateTime datEnd);
        Task<List<MentoredQueryResult>> GetAllMentoredAndCompaniesPaymentAsync(DateTime datInit, DateTime datEnd);
        Task<GetMentoredAndPartnerQueryResult> GetMentoredAndPartner(int id);
        Task<List<Mentored>> GetAllByBirthdayMonth(string month);
    }
}
