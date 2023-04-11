using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.DTO;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class CustomerApp : AppBaseCRUD<Customer, int>, ICustomerApp
    {
        #region Properties
        private readonly ICustomerService _customerService;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public CustomerApp(ICustomerService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _customerService = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        #region Methods
        public Task<List<Customer>> GetByNameAsync(string name) => _customerService.GetByNameAsync(name);
        public async Task<List<Customer>> GetAllPagination(QueryCustomerDTO query)
        {
            var pageOptions = new PaginationDTO(query.PageIndex, query.PageSize);
            var result = await _customerService.GetAllPagination(query.Name, query.Email, pageOptions);
            return result;
        }
        public async Task<Customer> Create(CustomerDTO lead)
        {
            // Busca o cliente
            //var customerCpf = await _customerService.GetByDocumentAsync(lead.Document);
            var customerEmail = await _customerService.GetByEmailAsync(lead.Email);

            //if (customerCpf != null)
            //{
            //    _notification.Handle(new DomainNotification("CustomerEmailInUse", "O Documento informado está indisponível."));
            //    return null;
            //}
            if (customerEmail != null)
            {
                _notification.Handle(new DomainNotification("CustomerEmailInUse", "O e-mail informado está indisponível."));
                return null;
            }

            // Adiciona o cliente
            var customer = new Customer(lead.Name.Trim(), lead.Email.Trim(), lead.RG?.Trim(), lead.Document?.Trim(), lead.PhoneNumber?.Trim(), lead.BirthDate, lead.Address.ZipCode?.Trim(), lead.Address.Street?.Trim(), lead.Address.Number?.Trim(),
                lead.Address.Complement?.Trim(), lead.Address.District?.Trim(), lead.Address.City?.Trim(), lead.Address.Country?.Trim(), lead.Address.State?.Trim(), lead.Note?.Trim());

            await base.AddAsync(customer);

            return customer;
        }

        public async Task<Customer> UpdateAsync(CustomerUpdateDTO dto)
        {
            var customer = await GetByIdAsync(dto.Id);
            if (customer == null)
            {
                _notification.Handle(new DomainNotification("CustomerInvalid", $"Cliente não encontrado."));
                return null;
            }

            // Valida se o e-mail está disponível
            if (customer.Email.Trim() != dto.Email.Trim())
            {
                if (await _customerService.CheckEmailInUse(dto.Email.Trim(), dto.Id))
                {
                    _notification.Handle(new DomainNotification("CustomerEmailInUse", "O e-mail informado está indisponível."));
                    return null;
                }

                if (await _userservice.CheckEmailInUse(dto.Email.Trim(), customer.UserId))
                {
                    _notification.Handle(new DomainNotification("CustomerEmailInUse", "O e-mail informado está indisponível."));
                    return null;
                }
            }

            // Valida se o CPF está disponível
            if (customer.Document != null && customer.Document.Trim() != dto.Document.Trim())
            {
                if (await _customerService.CheckDocumentInUse(dto.Document.Trim(), dto.Id))
                {
                    _notification.Handle(new DomainNotification("CustomerCPFInUse", "O Documento informado está indisponível."));
                    return null;
                }

                if (await _userservice.CheckEmailInUse(dto.Email.Trim(), customer.UserId))
                {
                    _notification.Handle(new DomainNotification("CustomerDocumentInUse", "O Documento informado está indisponível."));
                    return null;
                }
            }

            // Atualiza o cliente
            customer.Update(dto.Name.Trim(), dto.Email.Trim(), dto.RG?.Trim(), dto.Document?.Trim(), dto.PhoneNumber?.Trim(), dto.BirthDate, dto.ZipCode?.Trim(), dto.Street?.Trim(), dto.Number?.Trim(),
                    dto.Complement?.Trim(), dto.District?.Trim(), dto.City?.Trim(), dto.Country?.Trim(), dto.State?.Trim(), dto.Note?.Trim());

            customer.SetUserChangeId(_user.Id.Value);

            var result = await base.UpdateAsync(customer);

            // Atualiza o e-mail na tabela de usuários
            if (result && customer.Email.Trim() != dto.Email.Trim())
            {
                var user = await _userApp.FindById(customer.UserId.Value);
                user.SetEmail(dto.Email.Trim());
                await _userservice.Update(user);
            }

            return customer;
        }

        public async Task<int?> QuantityCustomers()
        {
            var result = await _customerService.QuantityCustomers();
            return result;
        }

        public async Task<int?> QuantityCustomersInProduct()
        {
            var result = await _customerService.QuantityCustomers();
            return result;
        }

        public async Task<Customer> GetByCpfAsync(string cpf)
        {
            var result = await _customerService.GetByDocumentAsync(cpf);
            return result;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);

            if (customer == null)
            {
                _notification.Handle(new DomainNotification("CustomerNotFound", "Cliente não encontrado"));
                return false;
            }
            await base.DeleteAsync(customer.Id);
            return true;
        }


        public async Task<bool> ImportExel(MemoryStream stream)
        {
            var list = new List<CustomerDTO>();
            DateTime? date;
            try
            {
                using (var pakage = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = pakage.Workbook.Worksheets[1];
                    var rowCount = worksheet.Dimension.Rows;
                    for (int row = 2; row <= rowCount; row++)
                    {
                        if (worksheet.Cells[row, 12].Value?.ToString().Trim() != null)
                        {
                            date = DateTime.Parse(worksheet.Cells[row, 12].Value?.ToString().Trim(), CultureInfo.CreateSpecificCulture("pt-BR"));
                        }
                        else
                        {
                            date = null;
                        }

                        if (worksheet.Cells[row, 1].Value?.ToString().Trim() != null)
                            list.Add(new CustomerDTO
                            {
                                Name = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                Email = worksheet.Cells[row, 2].Value.ToString().Trim(),
                                PhoneNumber = worksheet.Cells[row, 3].Value?.ToString().Trim(),
                                Document = worksheet.Cells[row, 4]?.Value?.ToString().Trim(),
                                Address = new AddressDTO
                                {
                                    ZipCode = worksheet.Cells[row, 5].Value?.ToString().Trim(),
                                    Street = worksheet.Cells[row, 6].Value?.ToString().Trim(),
                                    Number = worksheet.Cells[row, 7].Value?.ToString().Trim(),
                                    Complement = worksheet.Cells[row, 8].Value?.ToString().Trim(),
                                    District = worksheet.Cells[row, 9].Value?.ToString().Trim(),
                                    City = worksheet.Cells[row, 10].Value?.ToString().Trim(),
                                    State = worksheet.Cells[row, 11].Value?.ToString().Trim(),
                                },
                                BirthDate = date
                            });
                    }
                }
                var ret = await CreateAll(list);
                return ret;
            }
            catch (Exception e)
            {
                _notification.Handle(new DomainNotification("ErrorExcel", "Exitem campos incorretos na planilha. Verifique e tente novamente."));
            }
            return false;
        }

        public async Task<bool> CreateAll(List<CustomerDTO> customes)
        {
            var success = false;
            var inUse = false;
            try
            {
                foreach (var item in customes)
                {
                    //var customerCpf = await _customerService.GetByDocumentAsync(item.Document);
                    var customerEmail = await _customerService.GetByEmailAsync(item.Email);
                    if (customerEmail != null)
                    {
                        inUse = true;
                        continue;
                    }
                    else
                    {
                        // Adiciona o cliente
                        var customer = new Customer(item.Name, item.Email, item.RG, item.Document, item.PhoneNumber, item.BirthDate, item.Address.ZipCode, item.Address.Street, item.Address.Number,
                                                    item.Address.Complement, item.Address.District, item.Address.City, item.Address.Country, item.Address.State, item.Note);
                        success = await base.AddAsync(customer);
                    }

                }
            }
            catch (Exception e)
            {

                _notification.Handle(new DomainNotification("ErrorExcel", "Ocorreu um erro."));
            }

            //if (inUse)
            //{
            //    _notification.Handle(new DomainNotification("CustomerExist", "Um ou mais e-mails estão em uso e foram ignorados."));
            //    success = true;
            //}

            return success;
        }

        public async Task<bool> ChangeStatus(int customerId, CustomerStatusEnum status)
        {
            var customer = await GetByIdAsync(customerId);

            if (customer == null)
            {
                _notification.Handle(new DomainNotification("CustomerNotFound", "Aluno não encontrado."));
                return false;
            }

            customer.SetStatus(status);
            var result = await UpdateAsync(customer);
            return result;

            // Alterando o status
            //if (customer.Status != status)
            //{
            //    if (status == CustomerStatusEnum.Good)
            //    {
            //        customer.SetStatus(status);
            //        await UpdateAsync(customer);
            //        return true;
            //    }
            //    else if (status == CustomerStatusEnum.Regular)
            //    {
            //        customer.SetStatus(status);
            //        await UpdateAsync(customer);
            //        return true;
            //    }
            //    else
            //    {
            //        customer.SetStatus(CustomerStatusEnum.Alert);
            //        await UpdateAsync(customer);
            //        return true;
            //    }
            //}
        }

        #endregion
    }
}
