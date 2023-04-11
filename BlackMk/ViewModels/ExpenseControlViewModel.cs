using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Procard.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class ExpenseControlViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public int ProviderId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public DateTime PaymentDate { get; set; }
        public string ProviderName { get; set; }
        public string ExpenseCategoryName { get; set; }
        public string ImageUpload { get; set; }
        public string Extension { get; set; }
        public string UrlImage { get; set; }
        public string FileName { get; set; }
        public string Note { get; set; }
        public DeletedEnum? Deleted { get; set; }
        public PaymentStatusEnum? Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
