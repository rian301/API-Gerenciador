using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Product : EntityLog<Product, int>
    {
        #region Properties
        public string Name { get; private set; }
        public string TimeAccess { get; private set; }

        #endregion

        #region Constructors
        public Product()
        {

        }

        public Product(string name)
        {
            Name = name;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name, string time)
        {
            Name = name;
            TimeAccess = time;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Produto atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }

        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            RuleFor(c => c.TimeAccess)
                .NotEmpty().WithMessage("Temp ode acesso é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
