using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Black.API.Admin.ViewModels
{
    public class InvoiceReportViewModel
    {
        public int? Id { get; set; }
        public int MentoredId { get; set; }
        public string MentoredName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? EndSubscriptionDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? OverdueSince { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStatusEnum Status { get; set; }
        public List<int?> Categories { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
