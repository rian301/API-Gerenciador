using Black.Application.DTO;
using System.IO;
using System.Threading.Tasks;

namespace Black.Service.Integration.AzureStorage
{
    public interface IAzureStorageService
    {
        Task<bool> UploadFile(string containername, Stream filestream, string filename);
        Task<BlobFileDTO> DownloadFile(string containername, string filename);
    }
}
