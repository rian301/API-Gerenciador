using Black.API.Admin.ViewModels;
using System;

namespace BlackMk.ViewModels
{
    public class CustomerAwardViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime? DateReceiving { get; set; }
        public DateTime? DateResend { get; set; }
        public DateTime? DateDevolution { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public int CustomerId { get; set; }
        public int AwardId { get; set; }
    }
}
