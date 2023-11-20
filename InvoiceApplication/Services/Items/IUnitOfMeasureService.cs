using InvoiceApplication.Models.Items;

namespace InvoiceApplication.Services.Items
{
    public interface IUnitOfMeasureService
    {
        Task<List<UnitOfMeasure>> GetAllMeasureAsync();
        Task AddNewMeasureAsync(UnitOfMeasure measure);
        Task UpdateMeasureAsync(UnitOfMeasure measure);
        Task DeleteMeasureAsync(UnitOfMeasure measure);
        Task<UnitOfMeasure> GetMeasureByIdAsync(int id);
    }
}
