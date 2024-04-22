using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FluentBlazorEcommerce.Entities
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Username { get; set; }
        [MaxLength(50)]
        public string? Email { get; set; } // Nullable string

    }
}
