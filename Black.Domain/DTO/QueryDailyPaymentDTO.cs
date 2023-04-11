using System;

namespace Black.Domain.DTO
{
    public class QueryDailyPaymentDTO
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public DateTime? DateScheduled { get; set; }
        public string Provider { get; set; }
        public string Category { get; set; }
    }
}
