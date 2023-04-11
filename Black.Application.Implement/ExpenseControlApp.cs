using Black.Application.Implement.Base;
using Black.Domain.Core.Notifications;
using Black.Domain.Interfaces;
using Black.Domain.Models;
using Black.Service;
using Black.Service.Integration.AzureStorage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using Black.Domain.Core.Utils;
using System.Globalization;
using Black.Domain.Enums;
using Black.Domain.QuerieResult;

namespace Black.Application.Implement
{
    public class ExpenseControlApp : AppBaseCRUD<ExpenseControl, int>, IExpenseControlApp
    {
        #region Properties
        private readonly IExpenseControlService _service;
        private readonly IUserApp _userApp;
        private readonly IUserService _userservice;
        private readonly IConfiguration _configuration;
        private readonly IAzureStorageService _azureStorageService;
        static BaseFont fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
        #endregion

        #region Constructors
        public ExpenseControlApp(IExpenseControlService service, IConfiguration configuration, IAzureStorageService azureStorageService, INotificationHandler<DomainNotification> notification, IUser user, IUserApp userApp, IUserService userservice, IUnitOfWork uow) : base(service, notification, user, uow)
        {
            _service = service;
            _userApp = userApp;
            _userservice = userservice;
            _configuration = configuration;
            _azureStorageService = azureStorageService;
        }
        #endregion

        public async Task<ExpenseControl> AddExpense(ExpenseControl model)
        {
            var ex = new ExpenseControl(model.Description, model.ProviderId, model.Date, model.Value, model.PaymentDate, model.ExpenseCategoryId, model.Note);
            if (!ex.IsValid())
            {
                _notification.Handle(ex.ValidationResult.Errors);
                return null;
            }
            await base.UpdateAsync(ex);

            return ex;
        }

        public async Task<List<ExpenseControl>> GetByPeriod(DateTime dateInit, DateTime dateEnd)
        {
            var expense = await _service.GetByPeriod(dateInit, dateEnd);

            if (expense == null)
            {
                _notification.Handle(new DomainNotification("InvoiceInvalid", "Não foram encontrados gastos para o período informado."));
                return null;
            }

            return expense;
        }
        public async Task<MemoryStream> ReportExpenseControl(DateTime dateInit, DateTime dateEnd, ExpenseControlReportEnum type, List<int> categories)
        {
            Image pathImage = Image.GetInstance("https://arquivosblack.blob.core.windows.net/logo/logo-black-mk-241x189p.png");

            if (type == ExpenseControlReportEnum.All || type == ExpenseControlReportEnum.Customized)
            {
                var expenses = type == ExpenseControlReportEnum.All ? await _service.GetByPeriod(dateInit, dateEnd) :
                    await _service.GetByPeriodAndCategories(dateInit, dateEnd, categories);

                if (expenses.Count() <= 0)
                {
                    _notification.Handle(new DomainNotification("NotFoundExpenseControlRepost", "Nenhum dado encontrado no período informado."));
                    return null;
                }

                // Configuração da quantidade total de páginas
                int totalPages = 1;
                int totalRows = expenses.Count;
                if (totalRows > 24)
                    totalPages += (int)Math.Ceiling((totalRows - 24) / 29F);

                // Configuração do ducumento PDF
                var pxPorMm = 72 / 25.2F;
                var pdf = new iTextSharp.text.Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
                var nameFile = $"gastos.{DateTime.Now.ToString("dd.MM.yyyy")}.pdf";

                MemoryStream output = new MemoryStream();
                var writer = PdfWriter.GetInstance(pdf, output);
                writer.PageEvent = new EventPaginatorPDF(totalPages);
                pdf.Open();
                fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                // Adição do título
                var fontParagraph = new iTextSharp.text.Font(fontBase, 28, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                var title = type == ExpenseControlReportEnum.All ? new Paragraph("Gastos Externos Geral\n\n", fontParagraph) : new Paragraph("Gastos Externos Customizado\n\n", fontParagraph);
                title.Alignment = Element.ALIGN_LEFT;
                title.SpacingAfter = 4;
                pdf.Add(title);

                // Adicinando a imagem
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(pathImage);
                float razaoHeigthLogo = logo.Width / logo.Height;
                float heigthLogo = 32;
                float widthLogo = heigthLogo * razaoHeigthLogo;
                logo.ScaleToFit(widthLogo, heigthLogo);
                var marginLeft = pdf.PageSize.Width - pdf.RightMargin - widthLogo;
                var marginTop = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(marginLeft, marginTop);
                writer.DirectContent.AddImage(logo, false);

                var tableAll = ReportAll(expenses);
                if (tableAll != null)
                    pdf.Add(tableAll);

                pdf.Close();
                return output;
            }
            else
            {
                var expensesByCategory = _service.ReportByPeriod(dateInit, dateEnd);

                if (expensesByCategory.Count() <= 0)
                {
                    _notification.Handle(new DomainNotification("NotFoundExpenseControlRepost", "Nenhum dado encontrado no período informado."));
                    return null;
                }

                // Configuração da quantidade total de páginas
                int totalPages = 1;
                int totalRows = expensesByCategory.Count();
                if (totalRows > 24)
                    totalPages += (int)Math.Ceiling((totalRows - 24) / 29F);

                // Configuração do ducumento PDF
                var pxPorMm = 72 / 25.2F;
                var pdf = new iTextSharp.text.Document(PageSize.A4, 15 * pxPorMm, 15 * pxPorMm, 15 * pxPorMm, 20 * pxPorMm);
                var nameFile = $"gastos.{DateTime.Now.ToString("dd.MM.yyyy")}.pdf";

                MemoryStream output = new MemoryStream();
                var writer = PdfWriter.GetInstance(pdf, output);
                writer.PageEvent = new EventPaginatorPDF(totalPages);
                pdf.Open();
                fontBase = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                // Adição do título
                var fontParagraph = new iTextSharp.text.Font(fontBase, 28, iTextSharp.text.Font.NORMAL, BaseColor.Black);
                var title = new Paragraph("Gastos Externos por Categoria\n\n", fontParagraph);
                title.Alignment = Element.ALIGN_LEFT;
                title.SpacingAfter = 4;
                pdf.Add(title);

                // Adicinando a imagem
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(pathImage);
                float razaoHeigthLogo = logo.Width / logo.Height;
                float heigthLogo = 32;
                float widthLogo = heigthLogo * razaoHeigthLogo;
                logo.ScaleToFit(widthLogo, heigthLogo);
                var marginLeft = pdf.PageSize.Width - pdf.RightMargin - widthLogo;
                var marginTop = pdf.PageSize.Height - pdf.TopMargin - 54;
                logo.SetAbsolutePosition(marginLeft, marginTop);
                writer.DirectContent.AddImage(logo, false);

                var tableCategory = ReportCategory(expensesByCategory);
                if (tableCategory != null)
                    pdf.Add(tableCategory);

                pdf.Close();
                return output;

            }
        }

        #region Gastos Geral
        private PdfPTable ReportAll(List<ExpenseControl> expenses)
        {
            decimal total = 0;
            // Adicionando a tabela de gastos geral
            var table = new PdfPTable(4);
            float[] widthColumns = { 1f, 1f, 0.6f, 1f };
            table.SetWidths(widthColumns);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;

            // Adicionando as células de gastos geral
            CreateCelulaText(table, "Descrição", PdfCell.ALIGN_LEFT, true);
            CreateCelulaText(table, "Data do Gasto", PdfCell.ALIGN_CENTER, true);
            CreateCelulaText(table, "Valor", PdfCell.ALIGN_LEFT, true);
            CreateCelulaText(table, "Categoria", PdfCell.ALIGN_LEFT, true);

            // Adicionando os dados nas celulas de gastos geral
            foreach (var item in expenses)
            {
                CreateCelulaText(table, item.Description, PdfCell.ALIGN_LEFT, true);
                CreateCelulaText(table, item.Date.ToString("dd/MM/yyyy"), PdfCell.ALIGN_CENTER, true);
                CreateCelulaText(table, string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", item.Value), PdfCell.ALIGN_LEFT, true, true);
                CreateCelulaText(table, item.ExpenseCategory.Name, PdfCell.ALIGN_LEFT, true);
                total += item.Value;
            }

            CreateCelulaText(table, $"Total: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", total)}", PdfPCell.ALIGN_RIGHT, true, colspan: 4);

            return table;
        }
        #endregion

        #region Gastos por Categoria
        private PdfPTable ReportCategory(IEnumerable<ExpenseControlReportQueryResult> expenses)
        {
            decimal total = 0;
            // Adicionando a tabela de gastos geral
            var table = new PdfPTable(2);
            float[] widthColumns = { 1f, 1f};
            table.SetWidths(widthColumns);
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;
            table.DefaultCell.BorderWidth = 0;
            table.WidthPercentage = 100;

            // Adicionando as células de gastos geral
            CreateCelulaText(table, "Descrição", PdfCell.ALIGN_LEFT, true);
            CreateCelulaText(table, "Valor", PdfCell.ALIGN_LEFT, true);

            // Adicionando os dados nas celulas de gastos geral
            foreach (var item in expenses)
            {
                CreateCelulaText(table, item.Name, PdfCell.ALIGN_LEFT, true);
                CreateCelulaText(table, string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", item.Total), PdfCell.ALIGN_LEFT, true, true);
                total += item.Total;
            }

            CreateCelulaText(table, $"Total: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", total)}", PdfPCell.ALIGN_RIGHT, true, colspan: 4);

            return table;
        }
        #endregion

        #region Criar Células
        static void CreateCelulaText(PdfPTable table, string text, int alignHoriz = PdfPCell.ALIGN_LEFT, bool negrito = false,
                                    bool italic = false, int lengthFont = 12, int heigthCelula = 25, int colspan = 1)
        {
            int style = iTextSharp.text.Font.BOLDITALIC;

            if (negrito && italic)
            {
                style = iTextSharp.text.Font.BOLDITALIC;
            }
            else if (negrito)
            {
                style = iTextSharp.text.Font.BOLD;
            }
            else if (italic)
            {
                style = iTextSharp.text.Font.ITALIC;
            }
            var fontCelula = new iTextSharp.text.Font(fontBase, 12, iTextSharp.text.Font.NORMAL, BaseColor.Black);

            var bgColor = iTextSharp.text.BaseColor.White;
            if (table.Rows.Count % 2 == 1)
                bgColor = new BaseColor(0.95F, 0.95F, 0.95F);

            var celula = new PdfPCell(new Phrase(text, fontCelula));
            celula.HorizontalAlignment = alignHoriz;
            celula.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            celula.Border = 0;
            celula.BorderWidthBottom = 1;
            celula.FixedHeight = heigthCelula;
            celula.PaddingBottom = 5;
            celula.BackgroundColor = bgColor;
            celula.Colspan = colspan;
            table.AddCell(celula);
        }
        #endregion
    }
}
