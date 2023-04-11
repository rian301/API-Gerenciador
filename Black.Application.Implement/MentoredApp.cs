using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class MentoredApp : AppBaseCRUD<Mentored, int>, IMentoredApp
    {
        #region Properties
        private readonly IMentoredService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        private readonly IPartnerApp _partnerApp;
        #endregion

        #region Constructors
        public MentoredApp(IMentoredService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IPartnerApp partnerApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
            _partnerApp = partnerApp;
        }
        #endregion

        public Task<List<Mentored>> GetAllMentoredAndCompany() => _service.GetAllMentoredAndCompany();
        public Task<List<Mentored>> GetAllMentoredAndCompaniesAsync(DateTime datInit, DateTime datEnd) => _service.GetAllMentoredAndCompaniesAsync(datInit, datEnd);
        public Task<List<MentoredQueryResult>> GetAllMentoredAndCompaniesPaymentAsync(DateTime datInit, DateTime datEnd) => _service.GetAllMentoredAndCompaniesPaymentAsync(datInit, datEnd);
        public Task<Mentored> GetMentoredAndCompany(int id) => _service.GetMentoredAndCompany(id);
        public Task<GetMentoredAndPartnerQueryResult> GetMentoredAndPartner(int id) => _service.GetMentoredAndPartner(id);
        public Task<List<Mentored>> GetAllByBirthdayMonth(string month) => _service.GetAllByBirthdayMonth(month);

        public async Task<Mentored> CreateOrUpdateAsync(MentoredDTO obj)
        {
            var mentored = await GetByIdAsync(obj.Id);

            if (mentored == null)
            {
                var mentoredAdd = new Mentored(obj.Name, obj.Email, obj.RG, obj.CPF, obj.PhoneNumber, obj.BirthDate, obj.ZipCode, obj.Street, obj.Number, obj.Complement, obj.District,
                                obj.City, obj.Country, obj.State, obj.Note, obj.Instagram, obj.IsPartner);

                await base.AddAsync(mentoredAdd);
                return mentoredAdd;
            }

            mentored.Update(obj.Name, obj.Email, obj.RG, obj.CPF, obj.PhoneNumber, obj.BirthDate, obj.ZipCode, obj.Street, obj.Number, obj.Complement, obj.District,
                            obj.City, obj.Country, obj.State, obj.Note, obj.Instagram, obj.IsPartner, obj.Off);

            var allMentored = await _partnerApp.GetByMentoredId(mentored.Id);
            var listNotRemove = new List<Partner>();
            foreach (var item in obj.Partners)
            {
                var partner = await _partnerApp.GetByMentoredAndPartnerId(item.Value, mentored.Id);
                if (partner == null)
                {
                    var partnerFather = new Partner(obj.Id, item.Value);
                    //var partnerChild = new Partner(item.Value, obj.Id.Value);
                    await _partnerApp.AddAsync(partnerFather);
                    //await _partnerApp.AddAsync(partnerChild);
                }
                else
                {
                    var result = await _partnerApp.GetByMentoredPartnerId(partner.MentoredPartnerId);
                    listNotRemove.Add(result);

                    var listRemove = allMentored.Except(listNotRemove);

                    if (listRemove.Count() > 0)
                        await RemovePartner(listRemove);
                }
            }

            if (obj.Partners.Count() <= 0)
            {
                var remove = await _partnerApp.GetByMentoredId(mentored.Id);
                await RemovePartner(remove);
            }

            await _uow.SaveAsync();

            return mentored;
        }

        public async Task<bool> RemovePartner(IEnumerable<Partner> list)
        {
            foreach (var item in list)
            {
                await _partnerApp.DeleteAsync(item.Id);
            }
            return true;
        }

        public async Task<bool> ChangeStatus(int mentoredId, MentoredStatusEnum status)
        {
            var mentored = await GetByIdAsync(mentoredId);

            if (mentored == null)
            {
                _notification.Handle(new DomainNotification("MentoredNotFound", "Mentorado não encontrado."));
                return false;
            }

            mentored.SetStatus(status);
            await _uow.SaveAsync();
            return true;
        }
    }
}
