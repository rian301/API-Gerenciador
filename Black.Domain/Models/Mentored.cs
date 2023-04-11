
using FluentValidation;
using Black.Domain.Core.Models;
using Black.Infra.CrossCutting.Common.String;
using System;
using System.Collections.Generic;
using Black.Domain.Enums;

namespace Black.Domain.Models
{
    public class Mentored : EntityLog<Mentored, int>
    {
        #region Properties
        public string Name { get; private set; }
        public string Email { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string CPF { get; private set; }
        public string RG { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Street { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public string Complement { get; private set; }
        public int? Number { get; private set; }
        public string Instagram { get; private set; }
        public string Note { get; set; }
        public bool IsPartner { get; private set; }
        public string Off { get; private set; }
        public DeletedEnum? Deleted { get; private set; }
        public MentoredStatusEnum Status { get; private set; }
        public IEnumerable<Partner> Partners { get; set; }
        public IEnumerable<MentoredCompany> MentoredCompanies { get; set; }
        public IEnumerable<MentoredAward> MentoredAwards { get; set; }
        public IEnumerable<Award> Awards { get; set; }

        #endregion

        #region Constructors

        protected Mentored() { }

        public Mentored(string name, string email, string rg, string cpf, string phoneNumber, DateTime? birthDate, string zipCode, 
            string street, int? number, string complement, string district, string city, string country, string state, string note, string instagram, bool isPartner)
        {
            Name = name;
            Email = email;
            SetRG(rg);
            SetCPF(cpf);
            SetPhoneNumber(phoneNumber);
            BirthDate = birthDate;
            SetZipCode(zipCode);
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            Note = note;
            Instagram = instagram;
            IsPartner = isPartner;
            Status = MentoredStatusEnum.Active;
            CreatedAt = DateTime.Now;
            Deleted = DeletedEnum.No;
        }
        #endregion

        #region Methods

        public CommandResult Update(string name, string email, string rg, string cpf, string phoneNumber, DateTime? birthDate, string zipCode,
            string street, int? number, string complement, string district, string city, string country, string state, string note, string instagram, bool isPartner, string off)
        {
            Name = name;
            Email = email;
            SetRG(rg);
            SetCPF(cpf);
            SetPhoneNumber(phoneNumber);
            BirthDate = birthDate;
            SetZipCode(zipCode);
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            Note = note;
            IsPartner = isPartner;
            Instagram = instagram;
            Off = off;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Cliente atualizado com sucesso");
        }

        public void SetRG(string rg) { RG = rg.RemoverCaracterMascara(); }
        public void SetCPF(string cpf) { CPF = cpf.RemoverCaracterMascara(); }
        public void SetPhoneNumber(string telefone) { PhoneNumber = telefone.RemoverCaracterMascara(); }
        public void SetZipCode(string cep) { ZipCode = cep; }
        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetNote(string note) { Note = note; }
        public void SetIsPartner(bool isPartner) { IsPartner = isPartner; }
        public void SetStatus(MentoredStatusEnum status) { Status = status; }
        public bool SetDeleted()
        {
            Deleted = DeletedEnum.Yes;
            return ValidationResult.IsValid;
        }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
