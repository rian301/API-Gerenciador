using System;
using System.ComponentModel.DataAnnotations;

namespace Black.Application.DTO
{
    public class CustomerDTO
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Note { get; set; }
        public AddressDTO Address { get; set; }
    }
}
