using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class Sent : EntityLog<Sent, int>
    {
        #region Properties
        public int AwardId { get; private set; }
        public int? CustomerId { get; private set; }
        public int? MentoredId { get; private set; }
        public DateTime? DateRequest { get; private set; }
        public DateTime? DateSend { get; private set; }
        public DateTime? DateReceiving { get; private set; }
        public string Requester { get; private set; }
        public string Campaign { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Code { get; private set; }
        public SentStatusEnum Status { get; private set; }
        public string ZipCode { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Complement { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
        public string State { get; private set; }
        public string Note { get; private set; }

        public Award Award { get; private set; }
        public Customer Customer { get; private set; }
        public Mentored Mentored { get; private set; }
        #endregion

        #region Constructors
        public Sent()
        {

        }

        public Sent(int awardId, int? customerId, int? mentoredId, DateTime? dateRequest, DateTime? dateSend, DateTime? dateReceiving, string requester, string campaign, string email, string phone, string code, SentStatusEnum status, string zipCode, string street, string number, string complement, string district, string city, string country, string state, string note)
        {
            AwardId = awardId;
            CustomerId = customerId;
            MentoredId = mentoredId;
            DateRequest = dateRequest;
            DateSend = dateSend;
            DateReceiving = dateReceiving;
            Requester = requester;
            Campaign = campaign;
            Email = email;
            Phone = phone;
            Code = code;
            Status = status;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            Note = note;
        }

        #endregion

        #region Methods
        public CommandResult Update(int awardId, int? customerId, int? mentoredId, DateTime? dateRequest, DateTime? dateSend, DateTime? dateReceiving, string requester, string campaign, string email, string phone, string code, SentStatusEnum status, string zipCode, string street, string number, string complement, string district, string city, string country, string state, string note)
        {
            AwardId = awardId;
            CustomerId = customerId;
            MentoredId = mentoredId;
            DateRequest = dateRequest;
            DateSend = dateSend;
            DateReceiving = dateReceiving;
            Requester = requester;
            Campaign = campaign;
            Email = email;
            Phone = phone;
            Code = code;
            Status = status;
            ZipCode = zipCode;
            Street = street;
            Number = number;
            Complement = complement;
            District = district;
            City = city;
            Country = country;
            State = state;
            Note = note;
            ChangedAt = DateTime.Now;

            return new CommandResult(true, "Envio atualizado com sucesso!");
        }

        public void SetUserChangeId(int userId) { UserIdChange = userId; }
        public void SetStatus(SentStatusEnum status) { Status = status; }
        #endregion

        #region Validators
        public override bool IsValid()
        {
            RuleFor(c => c.AwardId)
                .NotEmpty().WithMessage("Premiação é obrigatório");

            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
        #endregion
    }
}
