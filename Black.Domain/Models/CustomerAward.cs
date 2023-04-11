using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class CustomerAward : EntityLog<CustomerAward, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime DateSend { get; private set; }
        public DateTime? DateReceiving { get; private set; }
        public DateTime? DateDevolution { get; private set; }
        public DateTime? DateResend { get; private set; }
        public string Code { get; private set; }
        public string Note { get; set; }
        public int AwardId { get; private set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Award Award { get; set; }
        #endregion

        #region Constructors
        public CustomerAward()
        {

        }

        public CustomerAward(string name, DateTime dateSend, DateTime? dateReceiving, DateTime? dateDevolution, DateTime? dateResend, string code, string note, int awardId, int customerId)
        {
            Name = name;
            DateSend = dateSend;
            DateReceiving = dateReceiving;
            DateDevolution = dateDevolution;
            DateResend = dateResend;
            Code = code;
            Note = note;
            AwardId = awardId;
            CustomerId = customerId;
        }

        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime dateSend, DateTime? dateReceiving, DateTime? dateDevolution, DateTime? dateResend, string code, string note, int awardId, int customerId)
        {
            Name = name;
            DateSend = dateSend;
            DateReceiving = dateReceiving;
            DateDevolution = dateDevolution;
            DateResend = dateResend;
            Code = code;
            Note = note;
            AwardId = awardId;
            CustomerId = customerId;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Premiação atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
