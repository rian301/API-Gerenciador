using Black.API.Admin.ViewModels;

namespace BlackMk.ViewModels
{
    public class PartnerViewModel : BaseViewModel
    {
        public int MentoredId { get; set; }
        public int MentoredPartnerId { get; set; }
        public string PartnerName { get; set; }
    }
}
