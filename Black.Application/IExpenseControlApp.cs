using Black.Application.Base;
using Black.Application.DTO;
using Black.Domain.Enums;
using Black.Domain.Models;
using Black.Domain.QuerieResult;
using iTextSharp.text;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Black.Application
{
    public interface IExpenseControlApp : IAppBaseCRUD<ExpenseControl, int>
    {
        Task<List<ExpenseControl>> GetByPeriod(DateTime dateInit, DateTime dateEnd);
        Task<ExpenseControl> AddExpense(ExpenseControl model);
        Task<MemoryStream> ReportExpenseControl(DateTime dateInit, DateTime dateEnd, ExpenseControlReportEnum type, List<int> categories);    }
}
