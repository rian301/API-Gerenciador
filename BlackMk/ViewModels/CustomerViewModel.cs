using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;

namespace Black.API.Admin.ViewModels
{
    public class CustomerViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public CustomerStatusEnum Status { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
        public DateTime CreatedAt { get; set; }
        public string Note { get; set; }

    }
}
