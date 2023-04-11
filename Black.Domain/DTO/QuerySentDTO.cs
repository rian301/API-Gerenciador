using Black.Domain.Enums;

namespace Black.Domain.DTO
{
    public class QuerySentDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Customer { get; set; }
        public string Mentored { get; set; }
        public string Award { get; set; }
        public SentStatusEnum? Status { get; set; }
    }
}
