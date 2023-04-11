using Black.Application.Base;
using Black.Domain.Models;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IDocumentApp : IAppBaseCRUD<Document, int>
    {
        Task<int> QuantityDocuments();
    }
}
