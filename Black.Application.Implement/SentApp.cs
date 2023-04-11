using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class SentApp : AppBaseCRUD<Sent, int>, ISentApp
    {
        #region Properties
        private readonly ISentService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public SentApp(ISentService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        public Task<IQueryable<Sent>> GetAllPagination(QuerySentDTO filter)
        {
            var pageOptions = new PaginationDTO(filter.PageIndex, filter.PageSize);
            var result = _service.GetAllPagination(filter, pageOptions);
            return result;
        }

        public async Task<Sent> CreateOrUpdateAsync(Sent model)
        {
            var sent = await GetByIdAsync(model.Id);

            if (model.CustomerId != null)
            {
                var sentByAward = await _service.GetByAwardAsync(model.AwardId, model.CustomerId.Value, model.Id);

                if (sentByAward)
                {
                    _notification.Handle(new DomainNotification("CustomerAwardInUse", "O prêmio escolhido ja foi enviado para este aluno"));
                    return null;
                }
            }

            if (model.MentoredId != null)
            {
                var sentByAward = await _service.GetMentoredByAwardAsync(model.AwardId, model.MentoredId.Value, model.Id);

                if (sentByAward)
                {
                    _notification.Handle(new DomainNotification("MentoredAwardInUse", "O prêmio escolhido ja foi enviado para este mentorado"));
                    return null;
                }
            }

            if (model.DateSend != null)
                model.SetStatus(SentStatusEnum.Sent);

            if (model.DateReceiving != null)
                model.SetStatus(SentStatusEnum.Receiving);

            if(model.DateSend == null && model.DateReceiving == null)
                model.SetStatus(SentStatusEnum.InProgress);

            if (sent == null)
            {
                // Adiciona
                var sentModel = new Sent(model.AwardId, model.CustomerId, model.MentoredId, model.DateRequest, model.DateSend, model.DateReceiving, model.Requester, model.Campaign, model.Email, model.Phone, model.Code, model.Status, model.ZipCode, model.Street, model.Number, model.Complement, model.District, model.City, model.Country, model.State, model.Note);

                await base.AddAsync(sentModel);

                return sentModel;
            }

            sent.Update(model.AwardId, model.CustomerId, model.MentoredId, model.DateRequest, model.DateSend, model.DateReceiving, model.Requester, model.Campaign, model.Email, model.Phone, model.Code, model.Status, model.ZipCode, model.Street, model.Number, model.Complement, model.District, model.City, model.Country, model.State, model.Note);

            await _uow.SaveAsync();
            return sent;
        }
    }
}
