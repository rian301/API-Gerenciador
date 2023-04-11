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
    public interface IMentoredApp : IAppBaseCRUD<Mentored, int>
    {
        Task<List<Mentored>> GetAllMentoredAndCompany();
        Task<Mentored> GetMentoredAndCompany(int id);
        Task<List<Mentored>> GetAllMentoredAndCompaniesAsync(DateTime datInit, DateTime datEnd);
        Task<List<MentoredQueryResult>> GetAllMentoredAndCompaniesPaymentAsync(DateTime datInit, DateTime datEnd);
        Task<Mentored> CreateOrUpdateAsync(MentoredDTO obj);
        Task<GetMentoredAndPartnerQueryResult> GetMentoredAndPartner(int id);
        Task<List<Mentored>> GetAllByBirthdayMonth(string month);
        Task<bool> ChangeStatus(int mentoredId, MentoredStatusEnum status);
    }
}
