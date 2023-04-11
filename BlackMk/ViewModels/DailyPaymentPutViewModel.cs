using Black.API.Admin.ViewModels;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class DailyPaymentPutViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime? DatePayment { get; set; }
        public DateTime? DateSchedulingPayment { get; set; }
        public decimal Amount { get; set; }
        public string Document { get; set; }
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string Acount { get; set; }
        public string Pix { get; set; }
        public string Note { get; set; }
        public int ProviderId { get; set; }
        public int CategoryId { get; set; }
        public string ImageUpload { get; set; }
        public string Extension { get; set; }
        public string UrlImage { get; set; }
        public string FileName { get; set; }
        public DeletedEnum? Deleted { get; set; }
    }
}
