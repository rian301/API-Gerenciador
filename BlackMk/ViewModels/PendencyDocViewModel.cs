using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using Procard.Domain.Enums;
using System;

namespace Black.API.Admin.ViewModels
{
    public class PendencyDocViewModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public TypeDocEnum TypeDoc { get; set; }
        public string TypeDocDescription { get { return EnumUtil.GetDescriptions(TypeDoc); } }
        public bool Active { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? PendencyCompanyId { get; set; }
    }
}
