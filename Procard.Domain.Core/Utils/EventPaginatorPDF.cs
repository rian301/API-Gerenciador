using iTextSharp.text;
using iTextSharp.text.pdf;
using System;

namespace Black.Domain.Core.Utils
{
    public class EventPaginatorPDF : PdfPageEventHelper
    {
        private PdfContentByte wdc;
        private BaseFont FontBaseFooter { get; set; }
        private iTextSharp.text.Font FontFooter { get; set; }
        public int TotalPages { get; set; }

        public EventPaginatorPDF(int totalPages)
        {
            FontBaseFooter = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            FontFooter = new iTextSharp.text.Font(FontBaseFooter, 8f, iTextSharp.text.Font.NORMAL, BaseColor.Black);
            this.TotalPages = totalPages;
        }

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            base.OnOpenDocument(writer, document);
            this.wdc = writer.DirectContent;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            AddMomentGenerateReport(writer, document);
            AddNumberPage(writer, document);
        }

        private void AddMomentGenerateReport(PdfWriter writer, Document document)
        {
            var textMonmentGenerate = $"Gerado em {DateTime.Now.ToShortDateString()} às " + $"{DateTime.Now.ToLongTimeString()}";

           wdc.BeginText();
           wdc.SetFontAndSize(FontFooter.BaseFont, FontFooter.Size);
           wdc.SetTextMatrix(document.LeftMargin, document.BottomMargin * 0.75f);
           wdc.ShowText(textMonmentGenerate);
           wdc.EndText();
        }

        private void AddNumberPage(PdfWriter writer, Document document)
        {
            int pageAtual = writer.PageNumber;
            var textPagination = $"Página {pageAtual} de {TotalPages}";

            float whidthTextPage = FontBaseFooter.GetWidthPoint(textPagination, FontFooter.Size);
            var sizePage = document.PageSize;

            wdc.BeginText();
            wdc.SetFontAndSize(FontFooter.BaseFont, FontFooter.Size);
            wdc.SetTextMatrix(sizePage.Width - document.RightMargin - whidthTextPage, document.BottomMargin * 0.75f);
            wdc.ShowText(textPagination);
            wdc.EndText();
        }
    }
}
