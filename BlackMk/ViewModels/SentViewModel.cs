using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class SentViewModel : BaseViewModel
    {
        public int AwardId { get; set; }
        public string AwardName { get; set; }
        public int? CustomerId { get; set; }
        public int? MentoredId { get; set; }
        public string CustomerName { get; set; }
        public string MentoredName { get; set; }
        public DateTime? DateRequest { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateReceiving { get; set; }
        public string Requester { get; set; }
        public string Campaign { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Code { get; set; }
        public SentStatusEnum? Status { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string Note { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
