using System.ComponentModel.DataAnnotations;

namespace Lanchonete.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Lunch Lunch { get; set; }

        public int Amount { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
