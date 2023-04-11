using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class MentoredPayment : EntityLog<MentoredPayment, int>
    {
        public int MentoredId { get; set; }
        public int MentoredCompanyId { get; set; }
        public DateTime? SubscriptionDate { get; private set; }
        public DateTime? SubscriptionEndDate { get; private set; }
        public DateTime? PaymentDate { get; private set; }
        public DateTime? DueDate { get; private set; }
        public decimal InitialAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public PaymentTypeEnum PaymentMethodId { get; private set; }
        public int? Installments { get; private set; }
        public Mentored Mentored { get; set; }
        public MentoredCompany MentoredCompany { get; set; }

        public MentoredPayment()
        {

        }

        public MentoredPayment(int mentoredId, int companyId, DateTime? subscriptionDate, DateTime? subscriptionEndDate, DateTime dueDate, DateTime paymentDate, decimal initialAmount, decimal totalAmount, decimal discountAmount, PaymentTypeEnum paymentMethodId, int? installments)
        {
            MentoredId = mentoredId;
            MentoredCompanyId = companyId;
            SubscriptionDate = subscriptionDate;
            SubscriptionEndDate = subscriptionEndDate;
            DueDate = dueDate;
            PaymentDate = paymentDate;
            InitialAmount = initialAmount;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PaymentMethodId = paymentMethodId;
            Installments = installments;
        }

        public CommandResult Update(int mentoredId, int companyId, DateTime? subscriptionDate, DateTime? subscriptionEndDate, DateTime dueDate, DateTime paymentDate, decimal initialAmount, decimal totalAmount, decimal discountAmount, PaymentTypeEnum paymentMethodId, int? installments)
        {
            MentoredId = mentoredId;
            MentoredCompanyId = companyId;
            SubscriptionDate = subscriptionDate;
            SubscriptionEndDate = subscriptionEndDate;
            DueDate = dueDate;
            PaymentDate = paymentDate;
            InitialAmount = initialAmount;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            PaymentMethodId = paymentMethodId;
            Installments = installments;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Pagamento atualizada com sucesso");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }

        public override bool IsValid()
        {
            RuleFor(c => c.MentoredCompanyId)
                    .NotEmpty().WithMessage("Empresa é obrigatório");

            RuleFor(c => c.MentoredId)
                    .NotEmpty().WithMessage("Mentorado é obrigatório");

            RuleFor(c => c.InitialAmount)
                .NotEmpty().WithMessage("Valor inicial é obrigatório");

            RuleFor(c => c.TotalAmount)
                .NotEmpty().WithMessage("Valor total é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
