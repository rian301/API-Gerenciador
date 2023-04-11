using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class PurchaseControlViewModel : BaseViewModel
    {
        public string RequestName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Tracking { get; set; }
        public ResponsibleEnum? Responsible { get; set; }
        public DateTime? DateLimit { get; set; }
        public DateTime? DateSolicitation { get; set; }
        public DateTime? DatePurchase { get; set; }
        public DateTime? DateDelivery { get; set; }
        public decimal? Amount { get; set; }
        public PaymentTypeEnum? PaymentMethodId { get; set; }
        public string Note { get; set; }
        public int? ProviderId { get; set; }
        public int? Quantity { get; set; }
    }
}
