using SelectPdf;

namespace InvoiceApplication.Services.Pdf
{
    public class PdfService : IPdfService
    {
        public async Task<byte[]> CreateAsync(string pdfUrlView)
        {
            var view = new HtmlToPdf();
            var pdf = view.ConvertUrl(pdfUrlView);
            var pdfFile = pdf.Save();
            return pdfFile;

        }

        public async Task SavePdfAsync(byte[] bytesPdf)
        {
            using (var streamWriter = new StreamWriter("C:/Downloads/invoice.pdf"))
            {
                await streamWriter.BaseStream.WriteAsync(bytesPdf);
            }

        }
    }
}
