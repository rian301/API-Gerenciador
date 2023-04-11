using Black.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Black.Application.DTO
{
    public class EmployeeDTO
    {
        public int? Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
        public string Email { get; set; }
        public string RG { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DemissionDate { get; set; }
        public string Function { get; set; }
        public string MonthlyHour { get; set; }
        public string WorkSchedule { get; set; }
        public EmployeeGenderEnum? Gender { get; set; }
        public string PIS { get; set; }
        public string Mom { get; set; }
        public string Father { get; set; }
        public string Schooling { get; set; }
        public string Bank { get; set; }
        public string Agency { get; set; }
        public string Acount { get; set; }
        public string Pix { get; set; }
        public string VoterTitle { get; set; }
        public string ReservistCertificate { get; set; }
        public decimal? Wage { get; set; }
        public string Benefit { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public EmployeeStatusEnum? Status { get; set; }
        public string Note { get; set; }
        public int? UserId { get; set; }
        public EmployeeTypeEnum Type { get; set; }
        public AddressDTO Address { get; set; }
    }
}
