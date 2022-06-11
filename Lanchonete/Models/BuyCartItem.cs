using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lanchonete.Models
{
    [Table("CarrinhoCompraItens")]
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Lunch Lunche { get; set; }

        public int Amount { get; set; }

        [StringLength(200)]
        public string ShoppingCartId { get; set; }
    }
}
