using Lanchonete.Data;
using Lanchonete.Models;
using Lanchonete.Repositories.Interfaces;

namespace Lanchonete.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext,
            ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDispatched = DateTime.Now;
            _appDbContext.Orders.Add(order);
            _appDbContext.SaveChanges();

            var shoppingCartItems = _shoppingCart.ShoppingCartItems;

            foreach (var cartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetails()
                {
                    Amount = cartItem.Amount,
                    LunchId = cartItem.Lunch.LuchId,
                    OrderId = order.OrderId,
                    Price = cartItem.Lunch.Price
                };
                _appDbContext.OrderDetails.Add(orderDetail);
            }
            _appDbContext.SaveChanges();
        }
    }
}
