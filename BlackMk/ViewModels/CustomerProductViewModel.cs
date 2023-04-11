using Black.API.Admin.ViewModels;
using System;

namespace BlackMk.ViewModels
{
    public class CustomerProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime DatePurchase { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
