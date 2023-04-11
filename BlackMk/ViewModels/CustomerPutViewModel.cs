using System;

namespace Black.API.Admin.ViewModels
{
    public class CustomerPutViewModel : BaseViewModel
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
        public string Note { get; set; }

    }
}
