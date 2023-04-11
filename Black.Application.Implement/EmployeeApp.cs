using Black.Application.DTO;
using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Enums;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using System.Threading.Tasks;

namespace Black.Application.Implement
{
    public class EmployeeApp : AppBaseCRUD<Employee, int>, IEmployeeApp
    {
        #region Properties
        private readonly IEmployeeService _employeeService;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        #endregion

        #region Constructors
        public EmployeeApp(IEmployeeService service, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _employeeService = service;
            _userApp = userApp;
            _userservice = userservice;
        }
        #endregion

        #region Methods
        public async Task<Employee> Create(EmployeeDTO lead)
        {
            if (lead.CPF != null)
            {
                var employeeCpf = await _employeeService.GetByCPFAsync(lead.CPF);
                if (employeeCpf != null)
                {
                    _notification.Handle(new DomainNotification("EmployeeEmailInUse", "O CPF informado está indisponível."));
                    return null;
                }
            }

            if (lead.CNPJ != null)
            {
                var employeeCnpj = await _employeeService.GetByCNPJAsync(lead.CNPJ);
                if (employeeCnpj != null)
                {
                    _notification.Handle(new DomainNotification("EmployeeEmailInUse", "O CNPJ informado está indisponível."));
                    return null;
                }
            }

            if (lead.Email != null)
            {
                var employeeEmail = await _employeeService.GetByEmailAsync(lead.Email);

                if (employeeEmail != null)
                {
                    _notification.Handle(new DomainNotification("EmployeeEmailInUse", "O e-mail informado está indisponível."));
                    return null;
                }
            }

            // Adiciona o cliente
            var employee = new Employee(lead.Name, lead.Email, lead.RG, lead.CNPJ, lead.CPF, lead.PhoneNumber, lead.BirthDate, lead.AdmissionDate, lead.DemissionDate, lead.Function, lead.MonthlyHour,
                lead.WorkSchedule, lead.Gender, lead.PIS, lead.Mom, lead.Father, lead.Schooling, lead.Bank, lead.Agency, lead.Acount, lead.Pix, lead.VoterTitle, lead.ReservistCertificate, lead.Wage,
                lead.Benefit, lead.Address.ZipCode, lead.Address.Street, lead.Address.Number, lead.Address.Complement, lead.Address.District, lead.Address.City, lead.Address.Country,
                lead.Address.State, lead.Status, lead.Note, lead.UserId, lead.Type);

            employee.SetStatus(EmployeeStatusEnum.Active);

            await base.AddAsync(employee);

            return employee;
        }

        public async Task<Employee> UpdateAsync(EmployeeDTO dto)
        {
            var employee = await GetByIdAsync(dto.Id.Value);
            if (employee == null)
            {
                _notification.Handle(new DomainNotification("EmployeeInvalid", $"Cliente não encontrado."));
                return null;
            }

            // Valida se o e-mail está disponível
            if (employee.Email != null && employee.Email.Trim() != dto.Email.Trim())
            {
                if (await _employeeService.CheckEmailInUse(dto.Email.Trim(), dto.Id))
                {
                    _notification.Handle(new DomainNotification("EmployeeEmailInUse", "O e-mail informado está indisponível."));
                    return null;
                }

                if (await _userservice.CheckEmailInUse(dto.Email.Trim(), employee.UserId))
                {
                    _notification.Handle(new DomainNotification("EmployeeEmailInUse", "O e-mail informado está indisponível."));
                    return null;
                }
            }

            if (dto.CNPJ != null)
            {
                if (await _employeeService.CheckCNPJInUse(dto.CNPJ, employee.Id))
                {
                    _notification.Handle(new DomainNotification("EmployeeCNPJInUse", "O CNPJ informado está indisponível."));
                    return null;
                }
            }

            if (dto.CPF != null)
            {
                if (await _employeeService.CheckCPFInUse(dto.CPF, employee.Id))
                {
                    _notification.Handle(new DomainNotification("EmployeeCPFlInUse", "O CPF informado está indisponível."));
                    return null;
                }
            }


            // Atualiza o cliente
            employee.Update(dto.Name, dto.Email, dto.RG, dto.CNPJ, dto.CPF, dto.PhoneNumber, dto.BirthDate, dto.AdmissionDate, dto.DemissionDate, dto.Function, dto.MonthlyHour,
                dto.WorkSchedule, dto.Gender, dto.PIS, dto.Mom, dto.Father, dto.Schooling, dto.Bank, dto.Agency, dto.Acount, dto.Pix, dto.VoterTitle, dto.ReservistCertificate, dto.Wage,
                dto.Benefit, dto.Address.ZipCode, dto.Address.Street, dto.Address.Number, dto.Address.Complement, dto.Address.District, dto.Address.City, dto.Address.Country,
                dto.Address.State, dto.Status, dto.Note, dto.UserId, dto.Type);

            employee.SetUserChangeId(_user.Id.Value);

            var result = await base.UpdateAsync(employee);

            return employee;
        }

        public async Task<int?> QuantityEmployees()
        {
            var result = await _employeeService.QuantityEmployees();
            return result;
        }

        public async Task<int?> QuantityEmployeesInProduct()
        {
            var result = await _employeeService.QuantityEmployees();
            return result;
        }

        public async Task<Employee> GetByCpfAsync(string cpf)
        {
            var result = await _employeeService.GetByCPFAsync(cpf);
            return result;
        }

        public override async Task<bool> DeleteAsync(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
            {
                _notification.Handle(new DomainNotification("EmployeeNotFound", "Cliente não encontrado"));
                return false;
            }
            await base.DeleteAsync(employee.Id);
            return true;
        }
        public async Task<bool> ChangeStatus(int employeeId, EmployeeStatusEnum status)
        {
            var employee = await GetByIdAsync(employeeId);

            if (employee == null)
            {
                _notification.Handle(new DomainNotification("EmployeeNotFound", "Funcionário não encontrado."));
                return false;
            }

            employee.SetStatus(status);
            await base.UpdateAsync(employee);

            return true;
        }

        public async Task<bool> ChangeType(int employeeId, EmployeeTypeEnum type)
        {
            var employee = await GetByIdAsync(employeeId);

            if (employee == null)
            {
                _notification.Handle(new DomainNotification("EmployeeNotFound", "Funcionário não encontrado."));
                return false;
            }

            employee.SetType(type);
            await base.UpdateAsync(employee);

            return true;
        }

        #endregion
    }
}
