using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class AppViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime? DatePurchase { get; set; }
        public string Requester { get; set; }
        public decimal Value { get; set; }
        public string Signature { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public DateTime? DateCanceled { get; set; }
        public string MotiveCancel { get; set; }
        public AppStatusEnum? Status { get; set; }
        public string Note { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
