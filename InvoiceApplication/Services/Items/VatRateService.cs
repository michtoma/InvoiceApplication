using InvoiceApplication.Data;
using InvoiceApplication.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace InvoiceApplication.Services.Items
{
    public class VatRateService : IVatRateService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public VatRateService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<VatRate>> GetVatRatesAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.VatRate.ToListAsync();
        }
    }
}
