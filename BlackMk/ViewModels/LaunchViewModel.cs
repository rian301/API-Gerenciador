using Black.API.Admin.ViewModels;
using System;

namespace BlackMk.ViewModels
{
    public class LaunchViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int QuantityStudents { get; set; }
        public decimal Invoice { get; set; }
        public decimal Investment { get; set; }
        public string TopCriative { get; set; }
        public string Note { get; set; }
    }
}
