using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class PaymentMethod : EntityLog<PaymentMethod, int>
    {
        #region Properties
        public string Description { get; private set; }
        public PaymentTypeStatusEnum Status { get; set; }
        #endregion

        #region Constructors
        public PaymentMethod()
        {

        }

        public PaymentMethod(string description)
        {
            Description = description;
            CreatedAt = DateTime.Now;
        }
        #endregion

        #region Methods
        public CommandResult Update(string description)
        {
            Description = description;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Forma de pagamento atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetStatus(PaymentTypeStatusEnum status) { Status = status; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Descrição é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
