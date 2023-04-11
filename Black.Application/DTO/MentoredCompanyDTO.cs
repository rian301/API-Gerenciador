using Black.Domain.Enums;
using System;

namespace Black.Application.DTO
{
    public class MentoredCompanyDTO
    {
        public int? Id { get; set; }
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal InitialValue { get; set; }
        public decimal TotalValue { get; set; }
        public decimal DiscountValue { get; set; }
        public PaymentTypeEnum PaymentMethodId { get; set; }
        public int? Installments { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Note { get; set; }
        public MentoredCompanyStatusEnum? Status { get; set; }
        public int MentoredId { get; set; }
    }
}
