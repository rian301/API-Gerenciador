using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class CustomerPayment : EntityLog<CustomerPayment, int>
    {
        public PaymentTypeEnum PaymentMethodId { get; private set; }
        public DateTime? SignatureDate { get; private set; }
        public DateTime? CancelDate { get; private set; }
        public int? Installments { get; private set; }
        public string Note { get; private set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        #region Constructors
        public CustomerPayment()
        {

        }

        public CustomerPayment(PaymentTypeEnum paymentMethodId, DateTime? signatureDate, DateTime? cancelDate, int? installments, string note, int customerId)
        {
            PaymentMethodId = paymentMethodId;
            SignatureDate = signatureDate;
            CancelDate = cancelDate;
            Installments = installments;
            Note = note;
            CustomerId = customerId;
        }

        #endregion

        #region Methods
        public CommandResult Update(PaymentTypeEnum paymentMethodId, DateTime? signatureDate, DateTime? cancelDate, int? installments, string note, int customerId)
        {
            PaymentMethodId = paymentMethodId;
            SignatureDate = signatureDate;
            CancelDate = cancelDate;
            Installments = installments;
            Note = note;
            CustomerId = customerId;

            return new CommandResult(true, "Pagamento atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.PaymentMethodId)
                .NotEmpty().WithMessage("Forma de pagamento é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
