using System;

namespace Black.Domain.QuerieResult
{
    public class ExpenseControlReportQueryResult
    {
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Total { get; set; }
    }
}
