using FluentValidation;
using Black.Domain.Core.Models;
using Black.Domain.Enums;
using Black.Infra.CrossCutting.Common.String;
using Black.Infra.CrossCutting.Common.Validadores;
using System;
using System.Collections.Generic;

namespace Black.Domain.Models
{
    public class Customer : EntityLog<Customer, int>
    {
        #region Properties
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string RG { get; private set; }
        public string Document { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public CustomerStatusEnum Status { get; private set; }
        public int? UserId { get; private set; }
        public int? ProductId { get; private set; }
        public string Note { get; private set; }
        public string ImportCode { get; private set; }

        public IEnumerable<CustomerLaunch> CustomersLaunch { get; set; }
        public IEnumerable<CustomerProduct> CustomerProducts { get; set; }
        public IEnumerable<Award> Awards { get; set; }
        public IEnumerable<CustomerAward> CustomerAwards { get; set; }
        public IEnumerable<CustomerPayment> CustomerPayments { get; set; }

        #endregion

        #region Constructors

        protected Customer() { }

        public Customer(string name, string email, string rg, string document, string phoneNumber, DateTime? birthDate, string zipCode, 
            string street, string number, string complement, string district, string city, string country, string state, string note)
        {
            Name = name;
            Email = email;
            SetRG(rg);
            SetCPF(document);
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

            Status = CustomerStatusEnum.Good;
            CreatedAt = DateTime.Now;
        }
        #endregion

        #region Methods

        public CommandResult Update(string name, string email, string rg, string document, string phoneNumber, DateTime? birthDate, string zipCode,
            string street, string number, string complement, string district, string city, string country, string state, string note)
        {
            Name = name;
            Email = email;
            SetRG(rg);
            SetCPF(document);
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
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Cliente atualizado com sucesso");
        }

        public void SetRG(string rg) { RG = rg.RemoverCaracterMascara(); }
        public void SetCPF(string cpf) { Document = cpf.RemoverCaracterMascara(); }
        public void SetPhoneNumber(string telefone) { PhoneNumber = telefone.RemoverCaracterMascara(); }
        public void SetZipCode(string cep) { ZipCode = cep.RemoverCaracterMascara(); }
        public void SetStatus(CustomerStatusEnum status) { Status = status; }
        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetUserId(int userId) { UserId = userId; }
        public void SetProductId(int productId) { ProductId = productId; }
        public void SetNote(string note) { Note = note; }
        public void SetImportCode(string importCode) { ImportCode = importCode; }

        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("E-mail é obrigatório")
                .MaximumLength(255).WithMessage("E-mail não pode ter mais de 255 caracteres.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
