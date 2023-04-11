using Black.API.Admin.ViewModels;
using Black.Domain.Enums;
using System;
using System.Collections.Generic;

namespace BlackMk.ViewModels
{
    public class ReportExpenseControlViewModel : BaseViewModel
    {
        public DateTime DatInit { get; set; }
        public DateTime DatEnd { get; set; }
        public ExpenseControlReportEnum TypeReport { get; set; }
        public List<int> Categories { get; set; }
    }
}
