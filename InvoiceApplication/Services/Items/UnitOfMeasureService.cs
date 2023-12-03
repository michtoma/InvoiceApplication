using InvoiceApplication.Data;
using InvoiceApplication.Models.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

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
            using var _context = await _contextFactory.CreateDbContextAsync();
            _context.Add(measure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMeasureAsync(UnitOfMeasure measure)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            _context.Remove(measure);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UnitOfMeasure>> GetAllMeasureAsync()
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            return await _context.UnitOfMeasure.ToListAsync();
        }

        public async Task<UnitOfMeasure> GetMeasureByIdAsync(int id)
        {
            using var _context = await _contextFactory.CreateDbContextAsync();
            var measure = await _context.UnitOfMeasure.FindAsync(id);

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
            using var _context = await _contextFactory.CreateDbContextAsync();
            var existingMeasur = await _context.UnitOfMeasure.FindAsync(measure.Id);

            if (existingMeasur != null)
            {
                existingMeasur.Name = measure.Name;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Measure not found");
            }
        }
    }
}
