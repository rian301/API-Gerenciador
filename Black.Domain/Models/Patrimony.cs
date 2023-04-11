using Black.Domain.Core.Models;
using FluentValidation;
using Procard.Domain.Enums;
using System;

namespace Black.Domain.Models
{
    public class Patrimony : EntityLog<Patrimony, int>
    {
        #region Properties
        public string Description { get; private set; }
        public string Tag { get; private set; }
        public string Brand { get; private set; }
        public string Nf { get; private set; }
        public string NumberSerie { get; private set; }
        public DateTime? PurchaseDate { get; private set; }
        public decimal? Value { get; private set; }
        public string Note { get; private set; }
        public int? ProviderId { get; private set; }
        public int? AssetsCategoryId { get; private set; }
        public PatrimonyStatusEnum Status { get; set; }
        public Provider Provider { get; set; }
        public AssetsCategory AssetsCategory { get; set; }
        #endregion

        #region Constructors
        public Patrimony()
        {

        }

        public Patrimony(string description, string tag, string brand, string nf, string numberSerie, DateTime? purchaseDate, decimal? value, string note, int? providerId, int? assetsCategoryId, PatrimonyStatusEnum status)
        {
            Description = description;
            Tag = tag;
            Brand = brand;
            Nf = nf;
            NumberSerie = numberSerie;
            PurchaseDate = purchaseDate;
            Value = value;
            Note = note;
            ProviderId = providerId;
            AssetsCategoryId = assetsCategoryId;
            Status = status;
        }

        #endregion

        #region Methods
        public CommandResult Update(string description, string tag, string brand, string nf, string numberSerie, DateTime? purchaseDate, decimal? value, string note, int? providerId, int? assetsCategoryId, PatrimonyStatusEnum status)
        {
            Description = description;
            Tag = tag;
            Brand = brand;
            Nf = nf;
            NumberSerie = numberSerie;
            PurchaseDate = purchaseDate;
            Value = value;
            Note = note;
            ProviderId = providerId;
            AssetsCategoryId = assetsCategoryId;
            Status = status;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Patrimônio atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("Descrição é obrigatório");
            RuleFor(c => c.Status)
                .NotEmpty().WithMessage("Descrição é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
