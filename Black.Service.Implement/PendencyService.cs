using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class PendencyService : ServiceBaseCRUD<Pendency, int>, IPendencyService
    {
        #region Properties
        private readonly IPendencyRepository _repository;
        #endregion

        #region Constructors
        public PendencyService(IPendencyRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        //public IEnumerable<Pendency> GetAllActiveInCheckout()
        //{
        //    return _repository.TableNoTracking().Where(w => w.Active && w.ActiveInCheckout).ToList();
        //}

        //public IEnumerable<Pendency> GetAllActiveInCheckoutOffline()
        //{
        //    return _repository.TableNoTracking().Where(w => w.Active && w.ActiveInCheckoutOffline).ToList();
        //}
        public Task<Pendency> GetByDescriptionAsync(string description) => _repository.GetByDescriptionAsync(description);

        #endregion
    }
}
