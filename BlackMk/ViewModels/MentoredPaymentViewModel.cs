using Black.API.Admin.ViewModels;
using Black.Domain.Enums;
using Black.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackMk.ViewModels
{
    public class MentoredPaymentViewModel : BaseViewModel
    {
        public int MentoredId { get; set; }
        public int MentoredCompanyId { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? SubscriptionEndDate { get; set; }
        public decimal InitialAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public PaymentTypeEnum PaymentMethodId { get; set; }
        public int? Installments { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }

    }
}
