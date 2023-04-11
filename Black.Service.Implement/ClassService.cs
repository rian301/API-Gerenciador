using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class ClassService : ServiceBaseCRUD<Class, int>, IClassService
    {
        #region Properties
        private readonly IClassRepository _repository;
        #endregion

        public ClassService(IClassRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
    }
}
