using Black.API.Admin.ViewModels;
using System;

namespace BlackMk.ViewModels
{
    public class CustomerLaunchViewModel : BaseViewModel
    {
        public string Nicho { get; set; }
        public decimal Invoice { get; set; }
        public string Instagram { get; set; }
        public string Testimonial { get; set; }
        public int CustomerId { get; set; }
    }
}
