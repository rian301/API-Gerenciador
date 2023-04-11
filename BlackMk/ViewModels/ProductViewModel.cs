using Black.API.Admin.ViewModels;

namespace BlackMk.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string TimeAccess { get; set; }
        public int? QuantityCustomers { get; set; }
        public int? QuantityMentoreds { get; set; }
    }
}
