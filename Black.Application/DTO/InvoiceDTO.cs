using Black.Domain.Enums;
using System;

namespace Black.Application.DTO
{
    public class InvoiceDTO
    {
        public int? Id { get; set; }
        public int SubscriptionId { get; set; }
        public int MentoredId { get; set; }
        public decimal? Amount { get; set; }
        public InvoiceStatusEnum Status { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? PaidDate { get; set; }
        public DateTime? CanceledDate { get; set; }
        public DateTime? NextAttempt { get; set; }
        public int? AttemptCount { get; set; }
    }
}
