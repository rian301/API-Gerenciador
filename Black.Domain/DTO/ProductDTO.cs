namespace Black.Domain.DTO
{
    public class ProductDTO
    {
        public ProductDTO(int id, string name, int quantityCustomers)
        {
            Id = id;
            Name = name;
            QuantityCustomers = quantityCustomers;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityCustomers { get; set; }
    }
}
