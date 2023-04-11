namespace Black.Domain.DTO
{
    public class QueryCustomerDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
