using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Award : EntityLog<Award, int>
    {
        #region Properties
        public string Name { get; private set; }
        #endregion

        #region Constructors
        public Award()
        {

        }

        public Award(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name)
        {
            Name = name;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Prêmio atualizado com sucesso!");
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
