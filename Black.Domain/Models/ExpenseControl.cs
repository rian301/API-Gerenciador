using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using Procard.Domain.Enums;
using System;

namespace Black.Domain.Models
{
    public class ExpenseControl : EntityLog<ExpenseControl, int>
    {
        #region Properties
        public string Description { get; private set; }
        public int ProviderId { get; set; }
        public int ExpenseCategoryId { get; set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public PaymentStatusEnum Status { get; private set; }
        public string Note { get; private set; }
        public DeletedEnum? Deleted { get; private set; }

        public Provider Provider { get; set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        #endregion

        #region Constructors
        public ExpenseControl()
        {

        }

        public ExpenseControl(string description, int providerId, DateTime date, decimal value, DateTime paymentDate, int expenseCategoryId, string note)
        {
            Description = description;
            ProviderId = providerId;
            Date = date;
            Value = value;
            PaymentDate = paymentDate;
            ExpenseCategoryId = expenseCategoryId;
            Note = note;
            Deleted = DeletedEnum.No;
        }

        #endregion

        #region Methods
        public CommandResult Update(string description, int providerId, DateTime date, decimal value, DateTime paymentDate, int expenseCategoryId, string note)
        {
            Description = description;
            ProviderId = providerId;
            Date = date;
            Value = value;
            PaymentDate = paymentDate;
            ExpenseCategoryId = expenseCategoryId;
            Note = note;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Gasto atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public bool SetDeleted()
        {
            Deleted = DeletedEnum.Yes;
            return ValidationResult.IsValid;
        }

        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Descriçáo é obrigatório");
            RuleFor(c => c.ProviderId)
                .NotEmpty().WithMessage("Fornecedor é obrigatório");
            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("Valor é obrigatório");
            RuleFor(c => c.Date)
                .NotEmpty().WithMessage("Data é obrigatório");
            RuleFor(c => c.PaymentDate)
                .NotEmpty().WithMessage("Data de pagamento é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
