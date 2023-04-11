using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class DailyPayment : EntityLog<DailyPayment, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime? DatePayment { get; private set; }
        public DateTime? DateSchedulingPayment { get; private set; }
        public decimal Amount { get; private set; }
        public string Document { get; private set; }
        public string Bank { get; private set; }
        public string Agency { get; private set; }
        public string Acount { get; private set; }
        public string Pix { get; private set; }
        public string Note { get; private set; }
        public int ProviderId { get; set; }
        public int CategoryId { get; set; }
        public Provider Provider { get; set; }
        public DeletedEnum? Deleted { get; private set; }
        public ExpenseCategory ExpenseCategory { get; set; }
        #endregion

        #region Constructors
        public DailyPayment()
        {

        }

        public DailyPayment(string name, DateTime? date, DateTime? dateSchedulingPayment, decimal amount, string document, string bank, string agency, string acount, string pix, string note, int providerId, int categoryId)
        {
            Name = name;
            DatePayment = date;
            DateSchedulingPayment = dateSchedulingPayment;
            Document = document;
            Bank = bank;
            Agency = agency;
            Acount = acount;
            Pix = pix;
            Note = note;
            ProviderId = providerId;
            CategoryId = categoryId;
            Amount = amount;
            Deleted = DeletedEnum.No;
        }

        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime? date, DateTime? dateSchedulingPayment, decimal amount, string document, string bank, string agency, string acount, string pix, string note, int providerId, int categoryId)
        {
            Name = name;
            DatePayment = date;
            DateSchedulingPayment = dateSchedulingPayment;
            Document = document;
            Bank = bank;
            Agency = agency;
            Acount = acount;
            Pix = pix;
            Note = note;
            ProviderId = providerId;
            CategoryId = categoryId;
            Amount = amount;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Pagamento atualizado com sucesso!");
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
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.ProviderId)
                .NotEmpty().WithMessage("Fornecedor é obrigatório");
            RuleFor(c => c.CategoryId)
                .NotEmpty().WithMessage("Categoria é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
