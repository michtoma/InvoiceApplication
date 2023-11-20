using InvoiceApplication.Data;
using InvoiceApplication.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Items
{
    public class VatRateService : IVatRateService
    {
        private readonly AppDbContext _dbContext;

        public VatRateService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<VatRate>> GetVatRatesAsync()
        {
            return await _dbContext.VatRate.ToListAsync();
        }
    }
}
