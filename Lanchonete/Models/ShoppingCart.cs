using Lanchonete.Data;
using Microsoft.EntityFrameworkCore;

namespace Lanchonete.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;

        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            //define uma sessão
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            //obtem um serviço do tipo do nosso contexto 
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o Id do carrinho
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CartId", cartId);

            //retorna o carrinho com o contexto e o Id atribuido ou obtido
            return new ShoppingCart(context)
            {
                ShoppingCartId = cartId
            };
        }

        public void AddItemShoppingCart(Lunch lunch)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                     s => s.Lunch.LuchId == lunch.LuchId &&
                     s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Lunch = lunch,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public int RemoveItemShoppingCart(Lunch lunch)
        {
            var shoppingCartItems = _context.ShoppingCartItems.SingleOrDefault(
                   s => s.Lunch.LuchId == lunch.LuchId &&
                   s.ShoppingCartId == ShoppingCartId);

            var AmountLocal = 0;

            if (shoppingCartItems != null)
            {
                if (shoppingCartItems.Amount > 1)
                {
                    shoppingCartItems.Amount--;
                    AmountLocal = shoppingCartItems.Amount;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(shoppingCartItems);
                }
            }
            _context.SaveChanges();
            return AmountLocal;
        }

        public List<ShoppingCartItem> GetItensCart()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems
                                                                     .Where(c => c.ShoppingCartId == ShoppingCartId)
                                                                     .Include(s => s.Lunch)
                                                                     .ToList());
        }
        public void ClearShoppingCart()
        {
            var cartItens = _context.ShoppingCartItems
                                    .Where(c => c.ShoppingCartId == ShoppingCartId);
            _context.ShoppingCartItems.RemoveRange(cartItens);
            _context.SaveChanges();
        }
        public decimal GetTotalAmountShoppingCart()
        {
            var total = _context.ShoppingCartItems
                                .Where(_c => _c.ShoppingCartId == ShoppingCartId)
                                .Select(c => c.Amount*c.Amount).Sum();
            return total;
        }

    }
}