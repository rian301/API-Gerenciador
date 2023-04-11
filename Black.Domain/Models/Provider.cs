using Black.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Black.Domain.Models
{
    public class Provider : EntityLog<Provider, int>
    {
        #region Properties
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Bank { get; private set; }
        public string Agency { get; private set; }
        public string Acount { get; private set; }
        public string Pix { get; private set; }
        #endregion

        #region Constructors
        public Provider()
        {

        }

        public Provider(string name, string document, string bank, string agency, string acount, string pix)
        {
            Name = name;
            Bank = bank;
            Document = document;
            Agency = agency;
            Acount = acount;
            Pix = pix;
        }

        #endregion

        #region Methods
        public CommandResult Update(string name, string document, string bank, string agency, string acount, string pix)
        {
            Name = name;
            Document = document;
            Bank = bank;
            Agency = agency;
            Acount = acount;
            Pix = pix;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Fornecedor atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
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
