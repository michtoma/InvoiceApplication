using InvoiceApplication.Data;
using InvoiceApplication.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Items
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public UnitOfMeasureService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task AddNewMeasureAsync(UnitOfMeasure measure)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Add(measure);
            await context.SaveChangesAsync();
        }

        public async Task DeleteMeasureAsync(UnitOfMeasure measure)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            context.Remove(measure);
            await context.SaveChangesAsync();
        }

        public async Task<List<UnitOfMeasure>> GetAllMeasureAsync()
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            return await context.UnitOfMeasure.ToListAsync();
        }

        public async Task<UnitOfMeasure> GetMeasureByIdAsync(int id)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var measure = await context.UnitOfMeasure.FindAsync(id);

            if (measure != null)
            {
                return measure;

            }
            else
            {
                throw new InvalidOperationException("Measure not found");
            }
        }

        public async Task UpdateMeasureAsync(UnitOfMeasure measure)
        {
            using var context = await _contextFactory.CreateDbContextAsync();
            var existingMeasur = await context.UnitOfMeasure.FindAsync(measure.Id);

            if (existingMeasur != null)
            {
                existingMeasur.Name = measure.Name;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Measure not found");
            }
        }
    }
}
