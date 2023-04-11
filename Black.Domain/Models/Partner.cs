using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Partner : EntityLog<Partner, int>
    {
        #region Properties
        public int MentoredId { get; set; }
        public int MentoredPartnerId { get; set; }
        public Mentored Mentored { get; set; }
        #endregion

        #region Constructors
        public Partner()
        {

        }

        public Partner(int mentoredId, int mentoredPartnerId)
        {
            MentoredId = mentoredId;
            MentoredPartnerId = mentoredPartnerId;
        }
        #endregion

        #region Methods
        public CommandResult Update(int mentoredId, int mentoredPartnerId)
        {
            MentoredId = mentoredId;
            MentoredPartnerId = mentoredPartnerId;
          ChangedAt = DateTime.Now;

            return new CommandResult(true, "Sócio atualizado com sucesso!");
        }

        public void SetUserChangeId(int? userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.MentoredId)
                .NotEmpty().WithMessage("Mentorado é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
