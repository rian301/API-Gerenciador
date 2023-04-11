using System;

namespace Black.Domain.QuerieResult
{
    public class GetAgentSalesQueryResult
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public DateTime CreatedAt { get; set; }
        //public InvoiceStatusEnum Status { get; set; }
        //public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
