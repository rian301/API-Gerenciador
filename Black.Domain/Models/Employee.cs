using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Employee : EntityLog<Employee, int>
    {
        #region Properties
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string RG { get; private set; }
        public string CNPJ { get; private set; }
        public string CPF { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public DateTime? AdmissionDate { get; private set; }
        public DateTime? DemissionDate { get; private set; }
        public string Function { get; private set; }
        public string MonthlyHour { get; private set; }
        public string WorkSchedule { get; private set; }
        public EmployeeGenderEnum? Gender { get; private set; }
        public string PIS { get; private set; }
        public string Mom { get; private set; }
        public string Father { get; private set; }
        public string Schooling { get; private set; }
        public string Bank { get; private set; }
        public string Agency { get; private set; }
        public string Acount { get; private set; }
        public string Pix { get; private set; }
        public string VoterTitle { get; private set; }
        public string ReservistCertificate { get; private set; }
        public decimal? Wage { get; private set; }
        public string Benefit { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public EmployeeStatusEnum? Status { get; private set; }
        public string Note { get; private set; }
        public int? UserId { get; private set; }
        public EmployeeTypeEnum Type { get; private set; }
        #endregion

        #region Constructors
        public Employee()
        {

        }

        public Employee(string name, string email, string rG, string cNPJ, string cPF, string phoneNumber, DateTime? birthDate, DateTime? admissionDate, DateTime? resignation, 
            string function, string monthlyHour, string workSchedule, EmployeeGenderEnum? gender, string pIS, string mom, string father, string schooling,
            string bank, string agency, string acount, string pix, string voterTitle, string reservistCertificate, decimal? wage, string benefit, string zipCode, string street,
            string number, string complement, string district, string city, string country, string state, EmployeeStatusEnum? status, string note, int? userId, EmployeeTypeEnum type)
        {
            Name = name;
            Email = email;
            RG = rG;
            CNPJ = cNPJ;
            CPF = cPF;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            AdmissionDate = admissionDate;
            DemissionDate = resignation;
            Function = function;
            MonthlyHour = monthlyHour;
            WorkSchedule = workSchedule;
            Gender = gender;
            PIS = pIS;
            Mom = mom;
            Father = father;
            Schooling = schooling;
            Bank = bank;
            Agency = agency;
            Acount = acount;
            Pix = pix;
            VoterTitle = voterTitle;
            ReservistCertificate = reservistCertificate;
            Wage = wage;
            Benefit = benefit;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            Status = status;
            Note = note;
            UserId = userId;
            Type = type;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name, string email, string rG, string cNPJ, string cPF, string phoneNumber, DateTime? birthDate, DateTime? admissionDate, DateTime? resignation,
            string function, string monthlyHour, string workSchedule, EmployeeGenderEnum? gender, string pIS, string mom, string father, string schooling,
            string bank, string agency, string acount, string pix, string voterTitle, string reservistCertificate, decimal? wage, string benefit, string zipCode, string street,
            string number, string complement, string district, string city, string country, string state, EmployeeStatusEnum? status, string note, int? userId, EmployeeTypeEnum type)
        {
            Name = name;
            Email = email;
            RG = rG;
            CNPJ = cNPJ;
            CPF = cPF;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            AdmissionDate = admissionDate;
            DemissionDate = resignation;
            Function = function;
            MonthlyHour = monthlyHour;
            WorkSchedule = workSchedule;
            Gender = gender;
            PIS = pIS;
            Mom = mom;
            Father = father;
            Schooling = schooling;
            Bank = bank;
            Agency = agency;
            Acount = acount;
            Pix = pix;
            VoterTitle = voterTitle;
            ReservistCertificate = reservistCertificate;
            Wage = wage;
            Benefit = benefit;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            Status = status;
            Note = note;
            UserId = userId;
            Type = type;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Fncionário atualizado com sucesso!");
        }

        public void SetUserChangeId(int? userId) { UserIdChange = userId; }
        public void SetStatus(EmployeeStatusEnum status) => Status = status;
        public void SetType(EmployeeTypeEnum type) => Type = type;
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
