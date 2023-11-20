using InvoiceApplication.Data;
using InvoiceApplication.Models.Items;
using Microsoft.EntityFrameworkCore;

namespace InvoiceApplication.Services.Items
{
    public class UnitOfMeasureService : IUnitOfMeasureService
    {
        private readonly AppDbContext _context;

        public UnitOfMeasureService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewMeasureAsync(UnitOfMeasure measure)
        {
            _context.Add(measure);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMeasureAsync(UnitOfMeasure measure)
        {
            _context.Remove(measure);
            await _context.SaveChangesAsync();
        }

        public async Task<List<UnitOfMeasure>> GetAllMeasureAsync()
        {
            return await _context.UnitOfMeasure.ToListAsync();
        }

        public async Task<UnitOfMeasure> GetMeasureByIdAsync(int id)
        {
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
