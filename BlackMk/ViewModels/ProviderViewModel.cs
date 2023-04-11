using Black.API.Admin.ViewModels;

namespace BlackMk.ViewModels
{
    public class ProviderViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Document { get; set; }
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string Acount { get; set; }
        public string Pix { get; set; }
    }
}
