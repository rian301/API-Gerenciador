using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class SubscriptionReportViewModel : BaseViewModel
    {
        public int MentoredId { get; set; }
        public string MentoredName { get; set; }
        public string ProductName { get; set; }
        public decimal? AmountTotalContract { get; set; }
        public DateTime? SubscriptionDate { get; private set; }
        public DateTime? EndSubscriptionDate { get; private set; }
        public SubscriptionStatusEnum Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
