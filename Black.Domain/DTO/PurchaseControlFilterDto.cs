using System;

namespace Black.Domain.DTO
{
    public class PurchaseControlFilterDto
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string RequestName { get; set; }
        public string Description { get; set; }
        public DateTime? DateLimit { get; set; }
        public DateTime? DateSolicitation { get; set; }
        public DateTime? DatePurchase { get; set; }
        public DateTime? DateDelivery { get; set; }
    }
}
