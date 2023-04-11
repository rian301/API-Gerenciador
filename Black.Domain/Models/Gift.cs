using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Gift : EntityLog<Gift, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime? DateIncluse { get; private set; }
        public string Responsible { get; private set; }
        public int Quantity { get; private set; }
        public int? Entrance { get; private set; }
        public int? Exit { get; private set; }
        #endregion

        #region Constructors
        public Gift()
        {

        }

        public Gift(string name, DateTime? dateIncluse, string responsible, int quantity, int? entrance, int? exit)
        {
            Name = name;
            DateIncluse = dateIncluse;
            Responsible = responsible;
            Quantity = quantity;
            Entrance = entrance;
            Exit = exit;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime? dateIncluse, string responsible, int quantity, int? entrance, int? exit)
        {
            Name = name;
            DateIncluse = dateIncluse;
            Responsible = responsible;
            Quantity = quantity;
            Entrance = entrance;
            Exit = exit;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Brinde atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.Quantity)
               .NotEmpty().WithMessage("Quantidade é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
