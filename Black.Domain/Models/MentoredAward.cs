using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class MentoredAward : EntityLog<MentoredAward, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime DateSend { get; private set; }
        public DateTime? DateReceiving { get; private set; }
        public string Note { get; set; }
        public int AwardId { get; private set; }
        public int MentoredId { get; set; }
        public Mentored Mentored { get; set; }
        public Award Award { get; set; }
        #endregion

        #region Constructors
        public MentoredAward()
        {

        }

        public MentoredAward(string name, DateTime dateSend, DateTime? dateReceiving, int awardId, int mentoredId, string note)
        {
            Name = name;
            DateSend = dateSend;
            DateReceiving = dateReceiving;
            Note = note;
            AwardId = awardId;
            MentoredId = mentoredId;
        }

        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime dateSend, DateTime? dateReceiving, int awardId, int mentoredId, string note)
        {
            Name = name;
            DateSend = dateSend;
            DateReceiving = dateReceiving;
            Note = note;
            AwardId = awardId;
            MentoredId = mentoredId;
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
