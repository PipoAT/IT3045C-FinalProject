using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FluentBlazorEcommerce.Entities
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; } // Nullable string
    }
}
