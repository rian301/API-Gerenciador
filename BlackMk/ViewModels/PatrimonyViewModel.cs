using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Procard.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class PatrimonyViewModel : BaseViewModel
    {
        public string Description { get; set; }
        public string Tag { get; set; }
        public string Brand { get; set; }
        public string Nf { get; set; }
        public string NumberSerie { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public decimal? Value { get; set; }
        public string Note { get; set; }
        public int? ProviderId { get; set; }
        public int? AssetsCategoryId { get; set; }
        public PatrimonyStatusEnum Status { get; set; }
    }
}
