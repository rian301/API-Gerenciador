using AutoMapper;
using Black.API.Controllers.Base;
using Black.Application;
using Black.Application.DTO;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.Framework.Web.Attributes;
using BlackMk.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlackMk.Controllers
{
    public class MentoredController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IMentoredApp _app;
        private readonly IMentoredCompanyApp _mentoredCompany;
        #endregion

        #region Constructors
        public MentoredController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IMentoredApp app, IMentoredCompanyApp mentoredCompany, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _app = app;
            _mentoredCompany = mentoredCompany;
        }

        #endregion

        #region Actions
        [HttpGet, Route("query/{month}/{companyName}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<IEnumerable<MentoredViewModel>>> GetAll(string month, string companyName)
        {
            var mentoredsVM = new List<MentoredViewModel>();
            var mentoreds = new List<Mentored>();
            if (month != null && month != "null")
                mentoreds = await _app.GetAllByBirthdayMonth(month);
            else
                mentoreds = await _app.GetAllAsync();

            foreach (var item in mentoreds)
            {
                var companies = await _mentoredCompany.GetAllCompanyByMentored(item.Id);
                item.MentoredCompanies = companies;
                item.BirthDate?.ToString("ddMMyyyy");
                var mentored = _mapper.Map<MentoredViewModel>(item);
                if (companies.Count() > 0)
                {
                    mentored.CompanyName = companies[0]?.CompanyName;
                    mentored.CNPJ = companies[0]?.CNPJ;
                    mentored.CompanyZipCode = companies[0]?.ZipCode;
                    mentored.CompanyStreet = companies[0]?.Street;
                    mentored.CompanyNumber = companies[0]?.Number;
                    mentored.CompanyComplement = companies[0]?.Complement;
                    mentored.CompanyDistrict = companies[0]?.District;
                    mentored.CompanyCity = companies[0]?.City;
                    mentored.CompanyState = companies[0]?.State;
                    mentored.CompanyNote = companies[0]?.Note;
                    mentored.CompanyStatus = companies[0]?.Status;
                }
                mentoredsVM.Add(mentored);
            }
            var mapped = _mapper.Map<IEnumerable<MentoredViewModel>>(mentoredsVM);
            return month == null || month == "null" ? ResolveReturn(mapped.OrderBy(x => x.Name)) : ResolveReturn(mapped.OrderBy(x => x.BirthDate?.Day));
        }

        [HttpGet, Route("period")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<IEnumerable<MentoredViewModel>>> GetAllByPeriod(DateTime datInit, DateTime datEnd)
        {
            var obj = await _app.GetAllMentoredAndCompaniesAsync(datInit, datEnd);
            return ResolveReturn(_mapper.Map<IEnumerable<MentoredViewModel>>(obj));
        }

        [HttpGet, Route("period-payment")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<IEnumerable<MentoredQueryResult>>> GetAllByPeriodAndPayment(DateTime datInit, DateTime datEnd)
        {
            var obj = await _app.GetAllMentoredAndCompaniesPaymentAsync(datInit, datEnd);
            return ResolveReturn(_mapper.Map<IEnumerable<MentoredQueryResult>>(obj));
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_VIEW })]
        public async Task<ActionResult<MentoredViewModel>> Get(int id)
        {
            var obj = await _app.GetMentoredAndCompany(id);
            var objVM = _mapper.Map<MentoredViewModel>(obj);

            //objVM.PartnersVM = partnerVM;

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredViewModel>> Post([FromBody] MentoredViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Status = MentoredStatusEnum.Active;

            var obj = _mapper.Map<MentoredDTO>(model);
            var returnMentored = await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<MentoredViewModel>(returnMentored));
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<MentoredViewModel>> Put(int id, [FromBody] MentoredViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;

            var obj = _mapper.Map<MentoredDTO>(model);
            await _app.CreateOrUpdateAsync(obj);

            return ResolveReturn(_mapper.Map<MentoredViewModel>(obj));
        }

        [HttpPost("{id:int}/status/{status}")]
        [Permission(Permissions = new string[] { PermissionConst.MENTORED_ADD })]
        public async Task<ActionResult<bool>> PostChangeStatus([FromRoute] int id, [FromRoute] MentoredStatusEnum status)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _app.ChangeStatus(id, status);
            return ResolveReturn(result);
        }

        [Permission(Permissions = new string[] { PermissionConst.MENTORED_REMOVE })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<DailyPaymentViewModel>>> Remove([FromRoute] int id)
        {
            var obj = await _app.GetByIdAsync(id);
            obj.SetUserChangeId(_user.Id.Value);
            var ret = obj.SetDeleted();
            await _app.UpdateAsync(obj);
            return ResolveReturn(ret);
        }
        #endregion
    }
}
