using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class CustomerPaymentViewModel : BaseViewModel
    {
        public DateTime? SignatureDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public int? Installments { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public PaymentTypeEnum PaymentMethodId { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(PaymentMethodId); } }

    }
}
