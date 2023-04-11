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
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using Black.Domain.Enums;
using Black.Domain.DTO;
using System.Linq;
using Black.Domain.Models;

namespace Black.API.Admin.Controllers
{
    public class CustomersController : ApiBaseController
    {
        #region Properties
        private readonly IMapper _mapper;
        private readonly ICustomerApp _customerApp;
        #endregion

        #region Constructors
        public CustomersController(ILogErroApp logErroApp, IUser user, INotificationHandler<DomainNotification> notification,
                                   ICustomerApp customerApp, IMapper mapper) : base(logErroApp, user, notification)
        {
            _mapper = mapper;
            _customerApp = customerApp;
        }

        #endregion

        #region Actions
        [HttpGet]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<IEnumerable<PaginationResponseDTO<CustomerViewModel>>>> GetAll([FromQuery] QueryCustomerDTO query)
        {
            var count = new List<Customer>();

            if (query.Name != null && query.Name != "null")
                count = await _customerApp.GetByNameAsync(query.Name);
            else
                count = await _customerApp.GetAllAsync();

            var obj = await _customerApp.GetAllPagination(query);

            var objVM = _mapper.Map<List<CustomerViewModel>>(obj);
            var ret = new PaginationResponseDTO<CustomerViewModel>(count.Count(), objVM);

            return ResolveReturn(ret);
        }

        [HttpGet, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_VIEW })]
        public async Task<ActionResult<CustomerViewModel>> Get(int id)
        {
            var obj = await _customerApp.GetByIdAsync(id);
            var objVM = _mapper.Map<CustomerViewModel>(obj);

            return ResolveReturn(objVM);
        }

        [HttpPost, Route("import-excel")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult> PostDocs([FromRoute] IFormFile file)
        {
            var success = false;
            if (file == null)
                return BadRequestRegraNegocio("Informe um arquivo válido");

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                using (var pakage = new ExcelPackage(stream))
                {
                    success = await _customerApp.ImportExel(stream);
                }
            }

            return ResolveReturn(success);
        }

        [HttpPost]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerPutViewModel>> Post([FromBody] CustomerPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var customer = await _customerApp.Create(new CustomerDTO()
            {
                Name = model.Name,
                Email = model.Email,
                RG = model.RG,
                Document = model.Document,
                PhoneNumber = model.PhoneNumber,
                BirthDate = model.BirthDate,
                Note = model.Note,
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
            var dto = _mapper.Map<CustomerDTO>(customer);
            return ResolveReturn(dto);
        }

        [HttpPost, Route("list")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerPutViewModel>> PostList([FromBody] List<CustomerPutViewModel> models)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            foreach (var model in models)
            {
                var customer = await _customerApp.Create(new CustomerDTO()
                {
                    Name = model.Name,
                    Email = model.Email,
                    RG = model.RG,
                    Document = model.Document,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate,
                    Note = model.Note,
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
            }
            return ResolveReturn(Ok());
        }

        [HttpPut, Route("{id:int}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<CustomerPutViewModel>> Put(int id, [FromBody] CustomerPutViewModel model)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            model.Id = id;
            var dto = _mapper.Map<CustomerUpdateDTO>(model);

            var result = await _customerApp.UpdateAsync(dto);

            return ResolveReturn(_mapper.Map<CustomerPutViewModel>(result));
        }

        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<List<CustomerViewModel>>> Remove([FromRoute] int id)
        {
            var ret = await _customerApp.DeleteAsync(id);
            return ResolveReturn(ret);
        }

        [HttpPost("{id:int}/status/{status}")]
        [Permission(Permissions = new string[] { PermissionConst.CUSTOMER_ADD })]
        public async Task<ActionResult<bool>> PostChangeStatus([FromRoute] int id, [FromRoute] CustomerStatusEnum status)
        {
            if (!ModelState.IsValid) return BadRequestModelState();

            var result = await _customerApp.ChangeStatus(id, status);
            return ResolveReturn(result);
        }
        #endregion
    }
}
