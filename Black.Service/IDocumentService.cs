using Black.Domain.Models;
using Black.Service.Base;
using System.Threading.Tasks;

namespace Black.Service
{
    public interface IDocumentService : IServiceBaseCRUD<Document, int>
    {
        Task<int> QuantityDocuments();
    }
}
