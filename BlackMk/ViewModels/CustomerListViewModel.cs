using Black.Domain.Core.Utils;
using Black.Domain.Enums;

namespace Black.API.Admin.ViewModels
{
    public class CustomerListViewModel : BaseViewModel
    {        
        public string Name { get; set; }
        public string Email { get; set; }
        public CustomerStatusEnum Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
