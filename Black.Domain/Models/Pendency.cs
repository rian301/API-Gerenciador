using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Pendency : EntityLog<Pendency, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime? IncludDate { get; private set; }
        public string Requester { get; private set; }
        public string Description { get; private set; }
        public string Responsible { get; private set; }
        public DateTime? ResolveDate { get; private set; }
        public PendencyStatusEnum Status { get; private set; }
        #endregion

        #region Constructors
        public Pendency()
        {

        }

        public Pendency(string name, DateTime? includDate, string requester, string description, string responsible, DateTime? resolveDate, PendencyStatusEnum status)
        {
            Name = name;
            IncludDate = includDate;
            Requester = requester;
            Description = description;
            Responsible = responsible;
            ResolveDate = resolveDate;
            Status = status;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime? includDate, string requester, string description, string responsible, DateTime? resolveDate, PendencyStatusEnum status)
        {
            Name = name;
            IncludDate = includDate;
            Requester = requester;
            Description = description;
            Responsible = responsible;
            ResolveDate = resolveDate;
            Status = status;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Pendência atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetStatus(PendencyStatusEnum status) { Status = status; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
