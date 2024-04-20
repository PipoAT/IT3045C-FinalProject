using System.ComponentModel.DataAnnotations.Schema;

namespace FluentBlazorEcommerce.Entities
{
    [Table("ShoppingCarts")]
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}

