using InvoiceApplication.Services.Companies;
using System.Text;

namespace InvoiceApplication.Services.Invoices
{
    public class NumberGenerator : INumberGenerator
    {
        private readonly IAppUserService _appUserService;
        private readonly IInvoiceService _invoiceService;

        public NumberGenerator(IInvoiceService invoiceService, IAppUserService appUserService)
        {
            _invoiceService = invoiceService;
            _appUserService = appUserService;
        }

        public async Task<string> GenerateInvoiceNumber(DateTime dateTime)
        {
            var user = await _appUserService.GetCurrentUser();
            var invoices = await _invoiceService.GetAllInvoiceAsync();
            var userInvoices = invoices.Where(i=>i.AppUserId==user.Id && i.CreateDate.Year==dateTime.Year && i.CreateDate.Month==dateTime.Month).ToList();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("FV/");
            stringBuilder.Append((userInvoices.Count()+1).ToString());
            stringBuilder.Append('/');
            stringBuilder.Append(dateTime.Month.ToString());
            stringBuilder.Append('/');
            stringBuilder.Append(dateTime.Year.ToString());
            return stringBuilder.ToString();
        }
    }
}
