using Azure.Storage.Blobs;
using Black.Application.DTO;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Black.Service.Integration.AzureStorage
{

    public class AzureStorageService : IAzureStorageService
    {
        private readonly IConfiguration _configuration;

        public AzureStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
        } 

        public async Task<BlobFileDTO> DownloadFile(string containername, string filename)
        {
            var strorageconn = _configuration.GetSection("Integration:AzureStorageBlob:Connection").Value;

            var container = new BlobContainerClient(strorageconn, containername);
            BlobClient blob = container.GetBlobClient(filename.ToLower());

            var resultDo = await blob.DownloadAsync();

            return new BlobFileDTO(filename, resultDo.Value.Content, resultDo.Value.ContentType);
        }

        public async Task<bool> UploadFile(string containername, Stream filestream, string filename)
        {
            var strorageconn = _configuration.GetSection("Integration:AzureStorageBlob:Connection").Value;

            var container = new BlobContainerClient(strorageconn, containername);
            await container.CreateIfNotExistsAsync();

            BlobClient blob = container.GetBlobClient(filename.ToLower());
            filestream.Position = 0;
            await blob.UploadAsync(filestream, overwrite: true);
            return true;
        }
    }
}
