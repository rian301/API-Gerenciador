using Black.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Black.Application.DTO
{
    public class MentoredDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public int? Number { get; set; }
        public string Instagram { get; set; }
        public string Note { get; set; }
        public bool IsPartner { get; set; }
        public string Off { get; set; }
        public MentoredStatusEnum Status { get; set; }
        public IEnumerable<int?> Partners { get; set; }
        public IEnumerable<MentoredCompanyDTO> MentoredCompanies { get; set; }
    }
}
