using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Repository;
using Black.Service.Implement.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class MentoredService : ServiceBaseCRUD<Mentored, int>, IMentoredService
    {
        #region Properties
        private readonly IMentoredRepository _repository;
        #endregion

        public MentoredService(IMentoredRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }

        public Task<List<Mentored>> GetAllMentoredAndCompany() => _repository.GetAllMentoredAndCompany();
        public Task<Mentored> GetMentoredAndCompany(int id) => _repository.GetMentoredAndCompany(id);
        public Task<List<Mentored>> GetAllMentoredAndCompaniesAsync(DateTime datInit, DateTime datEnd) => _repository.GetAllMentoredAndCompaniesAsync(datInit, datEnd);
        public Task<List<MentoredQueryResult>> GetAllMentoredAndCompaniesPaymentAsync(DateTime datInit, DateTime datEnd) => _repository.GetAllMentoredAndCompaniesPaymentAsync(datInit, datEnd);
        public Task<GetMentoredAndPartnerQueryResult> GetMentoredAndPartner(int id) => _repository.GetMentoredAndPartner(id);
        public Task<List<Mentored>> GetAllByBirthdayMonth(string month) => _repository.GetAllByBirthdayMonth(month);
    }
}
