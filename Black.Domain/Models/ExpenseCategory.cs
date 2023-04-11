using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class ExpenseCategory : EntityLog<ExpenseCategory, int>
    {
        #region Properties
        public string Name { get; private set; }
        #endregion

        #region Constructors
        public ExpenseCategory()
        {

        }

        public ExpenseCategory(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name)
        {
            Name = name;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Categoria atualizado com sucesso!");
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
