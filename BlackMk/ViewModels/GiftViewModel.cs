using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class GiftViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime? DateIncluse { get; set; }
        public string Responsible { get; set; }
        public int Quantity { get; set; }
        public int? Entrance { get; set; }
        public int? Exit { get; set; }
    }
}
