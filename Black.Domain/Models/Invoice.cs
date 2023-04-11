using Black.Domain.Core.Models;
using Black.Domain.Enums;
using Black.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Black.Domain.Models
{
    public class Invoice : EntityLog<Invoice, int>
    {
        #region Properties

        public int SubscriptionId { get; private set; }
        public int MentoredId { get; private set; }
        public decimal? Amount { get; private set; }        
        public InvoiceStatusEnum Status { get; private set; }
        public DateTime? ExpirationDate { get; private set; }
        public DateTime? PaidDate { get; private set; }
        public DateTime? CanceledDate { get; private set; }
        public DateTime? NextAttempt { get; private set; }
        public DateTime? OverdueSince { get; private set; }
        public int? AttemptCount { get; private set; }

        public Subscription Subscription { get; set; }
        public Mentored Mentored { get; set; }
        #endregion

        #region Constructors

        protected Invoice() { }

        public Invoice(int subscriptionId, int mentoredId, decimal? amount, DateTime? nextAttempt, DateTime? expirationDate, DateTime? paidDate)
        {
            SubscriptionId = subscriptionId;
            MentoredId = mentoredId;       
            Amount = amount;
            NextAttempt = nextAttempt;
            ExpirationDate = expirationDate;
            PaidDate = paidDate;
            Status = InvoiceStatusEnum.Pending;
        }
        #endregion

        #region Methods

        public CommandResult Update(int subscriptionId, int mentoredId, decimal? amount, DateTime? nextAttempt = null, DateTime? expirationDate = null, DateTime? paidDate = null)
        {
            SubscriptionId = subscriptionId;
            MentoredId = mentoredId;
            Amount = amount;
            NextAttempt = nextAttempt;
            ExpirationDate = expirationDate;
            Status = InvoiceStatusEnum.Pending;
            PaidDate = paidDate;
            return new CommandResult(true);
        }

        public void SetStatus(InvoiceStatusEnum status) => Status = status;
        public void SetAmount(decimal amount) => Amount = amount;
        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetOverdueSince(DateTime? overdueSince) => OverdueSince = overdueSince;
        public void SetNextAttempt(int attemptCount, DateTime nextAttempt) 
        {
            AttemptCount = attemptCount;
            NextAttempt = nextAttempt;
        }        

        #endregion

        #region Validators
        public override bool IsValid()
        {
            //RuleFor(c => c.Amount)
            //    .NotEmpty().WithMessage("Valor é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
