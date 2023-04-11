using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using Black.Infra.CrossCutting.Common.String;
using Black.Repository;
using Black.Service.Implement.Base;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class EmployeeService : ServiceBaseCRUD<Employee, int>, IEmployeeService
    {
        #region Properties

        private readonly IEmployeeRepository _employeeRepository;

        #endregion

        public EmployeeService(IEmployeeRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _employeeRepository = repository;
        }

        public Task<Employee> GetByEmailAsync(string email) => _employeeRepository.GetByEmailAsync(email);
        public Task<Employee> GetByCNPJAsync(string cnpj) => _employeeRepository.GetByCNPJAsync(cnpj.RemoverCaracterMascara());
        public Task<Employee> GetByCPFAsync(string cpf) => _employeeRepository.GetByCPFAsync(cpf.RemoverCaracterMascara());
        public Task<Employee> GetByUserIdAsync(int userId) => _employeeRepository.GetByUserIdAsync(userId);
        public Task<int> QuantityEmployees() => _employeeRepository.QuantityEmployee();
        public Task<bool> CheckEmailInUse(string email, int? ignoreId) => _employeeRepository.CheckEmailInUse(email, ignoreId);
        public Task<bool> CheckCNPJInUse(string cnpj, int? ignoreId) => _employeeRepository.CheckCNPJInUse(cnpj, ignoreId);
        public Task<bool> CheckCPFInUse(string cpf, int? ignoreId) => _employeeRepository.CheckCPFInUse(cpf, ignoreId);
    }
}
