using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class PendencyViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime? IncludDate { get; set; }
        public string Requester { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }
        public DateTime? ResolveDate { get; set; }
        public PendencyStatusEnum? Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
