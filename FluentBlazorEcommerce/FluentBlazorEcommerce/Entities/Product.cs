using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentBlazorEcommerce.Entities
{
    [Table("Products")]
    public class Product
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } // Nullable string
        [MaxLength(50)]
        public decimal Price { get; set; } // Ensure Price property is defined
        public string Description { get; set; } // Nullable string
    }
}
