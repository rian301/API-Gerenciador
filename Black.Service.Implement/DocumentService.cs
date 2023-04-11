using Black.Domain.Core.Notifications;
using Black.Domain.Models;
using Black.Repository;
using Black.Service.Implement.Base;
using System.Threading.Tasks;

namespace Black.Service.Implement
{
    public class DocumentService : ServiceBaseCRUD<Document, int>, IDocumentService
    {
        #region Properties
        private readonly IDocumentRepository _repository;
        #endregion

        public DocumentService(IDocumentRepository repository, INotificationHandler<DomainNotification> notification)
            : base(repository, notification)
        {
            _repository = repository;
        }
        public Task<int> QuantityDocuments() => _repository.QuantityDocuments();
    }
}
