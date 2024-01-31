using System.ComponentModel.DataAnnotations;

namespace InvoiceApplication.Models.Items
{
    public class UnitOfMeasure
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Short name is required")]
        public string ShortName { get; set; } = string.Empty;
        IEnumerable<Item>? Items { get; set; }
    }
}
