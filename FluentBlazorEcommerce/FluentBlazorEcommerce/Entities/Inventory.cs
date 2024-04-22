using System.ComponentModel.DataAnnotations.Schema;
namespace FluentBlazorEcommerce.Entities
{
    [Table("Inventories")]
    public class Inventory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
