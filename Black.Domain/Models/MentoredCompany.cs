using System;
using System.Collections.Generic;
using Black.Domain.Core.Models;
using Black.Domain.Enums;
using Black.Infra.CrossCutting.Common.String;
using Black.Infra.CrossCutting.Common.Validadores;
using FluentValidation;

namespace Black.Domain.Models
{
    public class MentoredCompany : EntityLog<MentoredCompany, int>
    {
        public string CompanyName { get; private set; }
        public string CNPJ { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Email { get; private set; }
        public string Instagram { get; private set; }
        public string Phone { get; private set; }
        public string Note { get; private set; }
        public DateTime? SubscriptionDate { get; private set; }
        public MentoredCompanyStatusEnum Status { get; private set; }
        public int MentoredId { get; set; }
        public Mentored Mentored { get; set; }
        public IEnumerable<MentoredPayment> MentoredPayments { get; set; }

        public MentoredCompany()
        {
        }

        public MentoredCompany(string companyName, string cNPJ, string zipCode, string street, string number, string complement, string district, string city, string state, string note, MentoredCompanyStatusEnum status, int mentoredId, DateTime? subscriptionDate, string email, string instagram, string phone)
        {
            CompanyName = companyName;
            CNPJ = cNPJ;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Note = note;
            Status = status;
            MentoredId = mentoredId;
            Email = email;
            Instagram = instagram;
            Phone = phone;
            CreatedAt = DateTime.Now;
            SubscriptionDate = subscriptionDate;
        }

        public CommandResult Update(string companyName, string cNPJ, string zipCode, string street, string number, string complement, string district, string city, string state, string note, MentoredCompanyStatusEnum status, int mentoredId, DateTime? subscriptionDate, string email, string instagram, string phone)
        {
            CompanyName = companyName;
            SetCNPJ(cNPJ);
            SetZipCode(zipCode);
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            State = state;
            Note = note;
            MentoredId = mentoredId;
            Email = email;
            Instagram = instagram;
            Phone = phone;
            ChangedAt = DateTime.Now;
            SubscriptionDate = subscriptionDate;

            return new CommandResult(true, "Empresa atualizada com sucesso");
        }

        public CommandResult UpdateStatus(MentoredCompanyStatusEnum status)
        {
            Status = status;

            return new CommandResult(true, "Status atualizado com sucesso");
        }

        public void SetZipCode(string cep) { ZipCode = cep.RemoverCaracterMascara(); }
        public void SetCNPJ(string cnpj) { CNPJ = cnpj.RemoverCaracterMascara(); }

        public override bool IsValid()
        {
            RuleFor(c => c.MentoredId)
                .NotEmpty().WithMessage("Mentorado é obrigatório");
            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.SubscriptionDate)
                .NotEmpty().WithMessage("Data de inscrição é obrigatório");

            RuleFor(c => c.CNPJ)
                .NotEmpty().WithMessage("CNPJ é obrigatório.")
                .MaximumLength(14).WithMessage("CNPJ não pode ter mais de 14 caracteres.")
                .Must(Validador.ValidarCNPJ).WithMessage("CNPJ é inválido.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
