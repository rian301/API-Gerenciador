using Black.Domain.Models;
using Black.Repository.Base;
using System.Threading.Tasks;

namespace Black.Repository
{
    public interface IDocumentRepository : IRepositoryBaseCRUD<Document, int>
    {
        Task<int> QuantityDocuments();
    }
}
