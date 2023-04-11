using Black.Domain.Core.Models;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class CustomerProduct : EntityLog<CustomerProduct, int>
    {
        #region Properties
        public string Name { get; private set; }
        public DateTime DatePurchase { get; private set; }
        public int ProductId { get; private set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        #endregion

        #region Constructors
        public CustomerProduct()
        {

        }

        public CustomerProduct(string name, DateTime date, int productId, int customerId)
        {
            Name = name;
            DatePurchase = date;
            ProductId = productId;
            CustomerId = customerId;
        }
        #endregion

        #region Methods
        public CommandResult Update(string name, DateTime date, int productId, int customerId)
        {
            Name = name;
            DatePurchase = date;
            ProductId = productId;
            CustomerId = customerId;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Produto atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.DatePurchase)
                .NotEmpty().WithMessage("Data de compra é obrigatório");

            RuleFor(c => c.ProductId)
                .NotEmpty().WithMessage("Produto é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
