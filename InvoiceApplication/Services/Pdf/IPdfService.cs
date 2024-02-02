namespace InvoiceApplication.Services.Pdf
{
    public interface IPdfService
    {
        Task<byte[]> CreateAsync(string pdfUrlView);
        Task SavePdfAsync(byte[] bytesPdf);
    }
}
