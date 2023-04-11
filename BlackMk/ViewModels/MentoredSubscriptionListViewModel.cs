using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Black.API.Admin.ViewModels
{
    public class MentoredSubscriptionListViewModel : BaseViewModel
    {        
        public decimal Amount { get; set; }
        public DateTime? CanceledDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public MentoredSubscriptionListProductViewModel Product { get; set; }
        public MentoredSubscriptionListAgentIndicationViewModel AgentIndication { get; set; }
        public IEnumerable<MentoredSubscriptionListInvoiceViewModel> Invoices { get; set; }
        public MentoredSubscriptionListInvoicePeriodViewModel CurrentPeriod { get; set; }
        public string MotiveCanceled { get; set; }
    }

    public class MentoredSubscriptionListProductViewModel : BaseViewModel
    {        
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }

    public class MentoredSubscriptionListAgentIndicationViewModel : BaseViewModel
    {        
        public string Name { get; set; }        
    }

    public class MentoredSubscriptionListMentoredViewModel : BaseViewModel
    {
        public string Name { get; set; }
    }

    public class MentoredSubscriptionListInvoiceViewModel : BaseViewModel
    {
        public int SubscriptionId { get; set; }
        public MentoredSubscriptionListInvoicePeriodViewModel Period { get; set; }
        public decimal Amount { get; set; }
        public InvoiceStatusEnum Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public string BoletoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class MentoredSubscriptionListInvoicePeriodViewModel : BaseViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Cycle { get; set; }
    }

    public class MentoredSubscriptionViewModel : BaseViewModel
    {
        public MentoredSubscriptionListMentoredViewModel Mentored { get; set; }
        public MentoredSubscriptionListProductViewModel Product { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CanceledDate { get; set; }
        public string MotiveCanceled { get; set; }
        public DateTime? OverdueSince { get;  set; }
    }
}
