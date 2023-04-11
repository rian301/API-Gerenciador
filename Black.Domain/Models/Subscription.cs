using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using Procard.Domain.Models;
using System;
using System.Collections.Generic;

namespace Black.Domain.Models
{
    public class Subscription : EntityLog<Subscription, int>
    {
        #region Properties
        public int ProductId { get; private set; }
        public int? MentoredCompanyId { get; private set; }
        public int MentoredId { get; private set; }
        public SubscriptionStatusEnum Status { get; private set; }
        public DateTime? CanceledDate { get; private set; }
        public DateTime? SubscriptionDate { get; private set; }
        public DateTime? EndSubscriptionDate { get; private set; }
        public int? CurrentPeriodId { get; private set; }
        public string MotiveCanceled { get; private set; }
        public DateTime? OverdueSince { get; private set; }
        public DateTime? RequestCancelDate { get; private set; }
        public DateTime? DueDate { get; private set; }
        public string RequestCancelMotive { get; private set; }

        public decimal InitialAmount { get; private set; }
        public decimal TotalAmount { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public int? Installments { get; private set; }

        public Product Product { get; set; }
        public Mentored Mentored { get; set; }
        public MentoredCompany MentoredCompany { get; set; }

        public IEnumerable<Invoice> Invoices { get; set; }

        #endregion

        #region Constructors

        protected Subscription() { }

        public Subscription(int productId, int mentoredId, int? mentoredCompanyId, DateTime? canceledDate, DateTime? subscriptionDate, DateTime? endSubscriptionDate, int? currentPeriodId, string motiveCanceled, DateTime? overdueSince, DateTime? requestCancelDate, DateTime? dueDate, string requestCancelMotive, decimal initialAmount, decimal totalAmount, decimal discountAmount, int? installments)
        {
            ProductId = productId;
            MentoredId = mentoredId;
            MentoredCompanyId = mentoredCompanyId;
            CanceledDate = canceledDate;
            SubscriptionDate = subscriptionDate;
            EndSubscriptionDate = endSubscriptionDate;
            CurrentPeriodId = currentPeriodId;
            MotiveCanceled = motiveCanceled;
            OverdueSince = overdueSince;
            RequestCancelDate = requestCancelDate;
            DueDate = dueDate;
            RequestCancelMotive = requestCancelMotive;
            InitialAmount = initialAmount;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            Installments = installments;
        }
        #endregion

        #region Methods
        public CommandResult Update(int productId, int mentoredId, int? mentoredCompanyId, DateTime? canceledDate, DateTime? subscriptionDate, DateTime? endSubscriptionDate, int? currentPeriodId, string motiveCanceled, DateTime? overdueSince, DateTime? requestCancelDate, DateTime? dueDate, string requestCancelMotive, decimal initialAmount, decimal totalAmount, decimal discountAmount, int? installments)
        {
            ProductId = productId;
            MentoredId = mentoredId;
            MentoredCompanyId = mentoredCompanyId;
            CanceledDate = canceledDate;
            SubscriptionDate = subscriptionDate;
            EndSubscriptionDate = endSubscriptionDate;
            CurrentPeriodId = currentPeriodId;
            MotiveCanceled = motiveCanceled;
            OverdueSince = overdueSince;
            RequestCancelDate = requestCancelDate;
            DueDate = dueDate;
            RequestCancelMotive = requestCancelMotive;
            InitialAmount = initialAmount;
            TotalAmount = totalAmount;
            DiscountAmount = discountAmount;
            Installments = installments;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Cliente atualizado com sucesso");
        }

        public void AddRequestCancel(string motive)
        {
            RequestCancelMotive = motive;
            RequestCancelDate = DateTime.Now;
        }
        public void SetMotiveCanceled(string motive) => MotiveCanceled = motive;
        public void SetOverdueSince(DateTime? overdueSince) => OverdueSince = overdueSince;
        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void ChangeStatus(SubscriptionStatusEnum status)
        {
            if (status == SubscriptionStatusEnum.Canceled)
                CanceledDate = DateTime.Now;
            else CanceledDate = null;

            Status = status;
        }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Produto é obrigatório");

            RuleFor(c => c.MentoredId)
                .NotEmpty().WithMessage("Mentorado é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
