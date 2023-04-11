using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class PurchaseControl : EntityLog<PurchaseControl, int>
    {
        #region Properties
        public string RequestName { get; private set; }
        public string Description { get; private set; }
        public string Link { get; private set; }
        public string Tracking { get; private set; }
        public ResponsibleEnum? Responsible { get; private set; }
        public DateTime? DateLimit { get; private set; }
        public DateTime? DateSolicitation { get; private set; }
        public DateTime? DatePurchase { get; private set; }
        public DateTime? DateDelivery { get; private set; }
        public decimal? Amount { get; private set; }
        public PaymentTypeEnum? PaymentMethodId { get; private set; }
        public string Note { get; private set; }
        public int? Quantity { get; private set; }
        public int? ProviderId { get; private set; }
        public Provider Provider { get; set; }
        #endregion

        #region Constructors
        public PurchaseControl(string requestName, string description, string link, string tracking, ResponsibleEnum? responsible, DateTime? dateLimit, DateTime? dateSolicitation, DateTime? datePurchase, DateTime? dateDelivery, decimal? amount, PaymentTypeEnum? paymentMethodId, string note, int? providerId, int? quantity)
        {
            RequestName = requestName;
            Description = description;
            Link = link;
            Tracking = tracking;
            Responsible = responsible;
            DateLimit = dateLimit;
            DateSolicitation = dateSolicitation;
            DatePurchase = datePurchase;
            DateDelivery = dateDelivery;
            Amount = amount;
            PaymentMethodId = paymentMethodId;
            Note = note;
            ProviderId = providerId;
            Quantity = quantity;
        }
        #endregion

        #region Methods

        public CommandResult Update(string requestName, string description, string link, string tracking, ResponsibleEnum? responsible, DateTime? dateLimit, DateTime? dateSolicitation, DateTime? datePurchase, DateTime? dateDelivery, decimal? amount, PaymentTypeEnum? paymentMethodId, string note, int? providerId, int? quantity)
        {
            RequestName = requestName;
            Description = description;
            Link = link;
            Tracking = tracking;
            Responsible = responsible;
            DateLimit = dateLimit;
            DateSolicitation = dateSolicitation;
            DatePurchase = datePurchase;
            DateDelivery = dateDelivery;
            Amount = amount;
            PaymentMethodId = paymentMethodId;
            Note = note;
            ProviderId = providerId;
            Quantity = quantity;

            return new CommandResult(true, "Controle de compras atualizado com sucesso!");
        }

        public void SetStatus(ResponsibleEnum value) => Responsible = value;
        public void SetUserChangeId(int userId) { UserIdChange = userId; }

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
