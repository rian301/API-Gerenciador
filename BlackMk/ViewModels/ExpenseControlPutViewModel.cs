using Black.API.Admin.ViewModels;
using Black.Domain.Enums;
using Procard.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class ExpenseControlPutViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public int ProviderId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatusEnum? Status { get; set; }
        public string Note { get; set; }
        public DeletedEnum? Deleted { get; set; }
    }
}
