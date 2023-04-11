using Black.Domain.Core.Utils;
using Black.Domain.Enums;

namespace Black.API.Admin.ViewModels
{
    public class PaymentMethodViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public PaymentTypeStatusEnum? Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
