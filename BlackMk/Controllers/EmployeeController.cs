using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Black.API.Admin.ViewModels;
using Black.Application;
using Black.Application.DTO;
using Black.Domain.Consts;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Infra.Framework.Web.Attributes;
using System.Threading.Tasks;
using Black.API.Controllers.Base;
using System.Collections.Generic;
using Black.Domain.Enums;

namespace Black.API.Admin.Controllers
{
    public class EmployeeController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly IEmployeeApp _employeeApp;
        #endregion

        #region Constructors
        public EmployeeController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   IEmployeeApp employeeApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _employeeApp = employeeApp;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.EMPLOYEE_VIEW })]
        public async Task<ActionResult<IEnumerable<EmployeeViewModel>>> GetAll()
        {
            var obj = await _employeeApp.GetAllAsync();
            var objVM = _mapper.Map<IEnumerable<EmployeeViewModel>>(obj);

            return ResolveReturn(objVM);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EMPLOYEE_VIEW })]
        public async Task<ActionResult<EmployeeViewModel>> Get(int id)
        {
            var obj = await _employeeApp.GetByIdAsync(id);
            var objVM = _mapper.Map<EmployeeViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.EMPLOYEE_ADD })]
        public async Task<ActionResult<EmployeeViewModel>> Post([FromBody] EmployeeViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var employee = await _employeeApp.Create(new EmployeeDTO()
            {
                Name = model.Name,
                Email = model.Email,
                RG = model.RG,
                CNPJ = model.CNPJ,
                CPF = model.CPF,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                AdmissionDate = model.AdmissionDate,
                Function = model.Function,
                Gender = model.Gender,
                VoterTitle = model.VoterTitle,
                Acount = model.Acount,
                Agency = model.Agency,
                Bank = model.Bank,
                Pix = model.Pix,
                Father = model.Father,
                Mom = model.Mom,
                MonthlyHour = model.MonthlyHour,
                PIS = model.PIS,
                ReservistCertificate = model.ReservistCertificate,
                Schooling = model.Schooling,
                Status = model.Status,
                Wage = model.Wage,
                Benefit = model.Benefit,
                WorkSchedule = model.WorkSchedule,
                Note = model.Note,
                Type = model.Type,
                Address = new AddressDTO()
                {
                    ZipCode = model.ZipCode,
                    Street = model.Street,
                    Number = model.Number,
                    Complement = model.Complement,
                    District = model.District,
                    City = model.City,
                    State = model.State
                }
            });
            var dto = _mapper.Map<EmployeeDTO>(employee);
            return ResolveReturn(dto);
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.EMPLOYEE_ADD })]
        public async Task<ActionResult<EmployeeViewModel>> Put(int id, [FromBody] EmployeeViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var dto = _mapper.Map<EmployeeDTO>(model);
            dto.Address = new AddressDTO()
            {
                ZipCode = model.ZipCode,
                Street = model.Street,
                Number = model.Number,
                Complement = model.Complement,
                District = model.District,
                City = model.City,
                State = model.State
            };

            var result = await _employeeApp.UpdateAsync(dto);

            return ResolveReturn(_mapper.Map<EmployeeViewModel>(result));
        }

        [Permission(Permissions = new string[] { PermissionConst.EMPLOYEE_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<EmployeeViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _employeeApp.DeleteAsync(id);
            return ResolveReturn(ret);
        }

        [HttpPost("{id:int}/status/{status}")]
        [Permission(Permissions = new string[] { PermissionConst.EMPLOYEE_ADD })]
        public async Task<ActionResult<bool>> PostChangeStatus([FromRoute] int id, [FromRoute] EmployeeStatusEnum status)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _employeeApp.ChangeStatus(id, status);
            return ResolveReturn(result);
        }
        #endregion
    }
}
