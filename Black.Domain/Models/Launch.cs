using Black.Domain.Core.Models;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Black.Domain.Models
{
    public class Launch : EntityLog<Launch, int>
    {
        #region Properties
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public int QuantityStudents { get; private set; }
        public decimal Invoice { get; private set; }
        public decimal Investment { get; private set; }
        public string TopCriative { get; private set; }
        public string Note { get; private set; }
        #endregion

        #region Constructors
        public Launch()
        {

        }

        public Launch(string description, DateTime date, int quantityStudents, decimal invoice, decimal investment, string topCriative, string note)
        {
            Description = description;
            Date = date;
            QuantityStudents = quantityStudents;
            Invoice = invoice;
            Investment = investment;
            TopCriative = topCriative;
            Note = note;
        }
        #endregion

        #region Methods
        public CommandResult Update(string description, DateTime date, int quantityStudents, decimal invoice, decimal investment, string topCriative, string note)
        {
            Description = description;
            Date = date;
            QuantityStudents = quantityStudents;
            Invoice = invoice;
            Investment = investment;
            TopCriative = topCriative;
            Note = note;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Lançamento atualizado com sucesso!");
        }

        public void SetNote(string note) { Note = note; }
        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Nome é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            RuleFor(c => c.Invoice)
                .NotEmpty().WithMessage("Fatura é obrigatório");

            RuleFor(c => c.Investment)
                .NotEmpty().WithMessage("Investimento é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
