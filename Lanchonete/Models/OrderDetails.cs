using System.ComponentModel.DataAnnotations.Schema;

namespace Lanchonete.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int OrderId { get; set; }
        public int LunchId { get; set; }
        public int Amount { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual Lunch Lunch { get; set; }
        public virtual Order Order { get; set; }
    }
}
