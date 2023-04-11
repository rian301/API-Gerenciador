using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class App : EntityLog<App, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime? DatePurchase { get; private set; }
        public string Requester { get; private set; }
        public decimal Value { get; private set; }
        public string Signature { get; private set; }
        public string Description { get; private set; }
        public string Responsible { get; private set; }
        public DateTime? DateCanceled { get; private set; }
        public string MotiveCancel { get; private set; }
        public AppStatusEnum Status { get; private set; }
        public string Note { get; private set; }
        #endregion

        #region Constructors
        public App()
        {

        }

        public App(string name, DateTime? datePurchase, string requester, decimal value, string signature, string description, string responsible, DateTime? dateCanceled, string motiveCancel, AppStatusEnum status, string note)
        {
            Name = name;
            DatePurchase = datePurchase;
            Requester = requester;
            Value = value;
            Signature = signature;
            Description = description;
            Responsible = responsible;
            DateCanceled = dateCanceled;
            MotiveCancel = motiveCancel;
            Status = status;
            Note = note;
        }

        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime? datePurchase, string requester, decimal value, string signature, string description, string responsible, DateTime? dateCanceled, string motiveCancel, AppStatusEnum status, string note)
        {
            Name = name;
            DatePurchase = datePurchase;
            Requester = requester;
            Value = value;
            Signature = signature;
            Description = description;
            Responsible = responsible;
            DateCanceled = dateCanceled;
            MotiveCancel = motiveCancel;
            Status = status;
            Note = note;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Aplicativo atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetStatus(AppStatusEnum status) { Status = status; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.Requester)
               .NotEmpty().WithMessage("Solicitante é obrigatório");
            RuleFor(c => c.Responsible)
               .NotEmpty().WithMessage("Responsável é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
