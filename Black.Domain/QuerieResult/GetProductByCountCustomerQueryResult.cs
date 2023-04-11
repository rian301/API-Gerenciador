namespace Black.Domain.QuerieResult
{
    public class GetProductByCountCustomerQueryResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityCustomers { get; set; }
        public int ProductId { get; set; }
        public string TimeAccess { get; set; }
    }
}
