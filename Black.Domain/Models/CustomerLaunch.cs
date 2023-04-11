using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class CustomerLaunch : EntityLog<CustomerLaunch, int>
    {
        #region Properties
        public string Nicho { get; private set; }
        public decimal Invoice { get; private set; }
        public string Instagram { get; private set; }
        public string Testimonial { get; private set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        #endregion

        #region Constructors
        public CustomerLaunch()
        {

        }

        public CustomerLaunch(string nicho, decimal invoice, string instagram, string testimonial, int customerId)
        {
            Nicho = nicho;
            Invoice = invoice;
            Instagram = instagram;
            Testimonial = testimonial;
            CustomerId = customerId;
        }
        #endregion

        #region Methods
        public CommandResult Update(string nicho, decimal invoice, string instagram, string testimonial, int customerId)
        {
            Nicho = nicho;
            Invoice = invoice;
            Instagram = instagram;
            Testimonial = testimonial;
            CustomerId = customerId;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Informações de lançamento atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Nicho)
                .NotEmpty().WithMessage("Nicho é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            RuleFor(c => c.Instagram)
                .NotEmpty().WithMessage("Instagram é obrigatório")
                .MaximumLength(255).WithMessage("Nome não pode ter mais de 255 caracteres.");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
