using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Class : EntityLog<Class, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public string LinkClass { get; private set; }
        public string LinkInfo { get; private set; }
        public string LinkCopy { get; private set; }
        public string LinkCreative { get; private set; }
        public string LinkTraffic { get; private set; }
        public string LinkRegister { get; private set; }
        #endregion

        #region Constructors
        public Class()
        {

        }

        public Class(string name, DateTime date, string linkClass, string linkInfo, string linkCopy, string linkCreative, string linkTraffic, string linkRegister)
        {
            Name = name;
            Date = date;
            LinkClass = linkClass;
            LinkInfo = linkInfo;
            LinkCopy = linkCopy;
            LinkCreative = linkCreative;
            LinkTraffic = linkTraffic;
            LinkRegister = linkRegister;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime date, string linkClass, string linkInfo, string linkCopy, string linkCreative, string linkTraffic, string linkRegister)
        {
            Name = name;
            Date = date;
            LinkClass = linkClass;
            LinkInfo = linkInfo;
            LinkCopy = linkCopy;
            LinkCreative = linkCreative;
            LinkTraffic = linkTraffic;
            LinkRegister = linkRegister;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Aulão atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome é obrigatório");
            RuleFor(c => c.Date)
                .NotEmpty().WithMessage("Data é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
