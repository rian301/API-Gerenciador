using System.IO;

namespace Black.Application.DTO
{
    public class BlobFileDTO
    {
        public BlobFileDTO(string filename, Stream content, string contentType)
        {
            Filename = filename;
            Content = content;
            ContentType = contentType;
        }

        public string Filename { get; set; }
        public Stream Content { get; set; }
        public string ContentType { get; set; }
    }
}
