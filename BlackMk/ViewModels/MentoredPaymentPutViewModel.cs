using Black.API.Admin.ViewModels;
using System;
using System.Collections.Generic;

namespace BlackMk.ViewModels
{
    public class MentoredPaymentPutViewModel : BaseViewModel
    {
        //public SubscriptionPutViewModel Subscription { get; set; }
        //public IEnumerable<InvoiceViewModel> Invoices { get; set; }
        public int ProductId { get; set; }
        public int MentoredId { get; set; }
        public int? MentoredCompanyId { get; set; }
        public DateTime? CanceledDate { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? EndSubscriptionDate { get; set; }
        public int? CurrentPeriodId { get; set; }
        public string MotiveCanceled { get; set; }
        public DateTime? OverdueSince { get; set; }
        public DateTime? RequestCancelDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string RequestCancelMotive { get; set; }

        public decimal InitialAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int? Installments { get; set; }
        public IEnumerable<InvoiceViewModel> Invoices { get; set; }
    }
}
