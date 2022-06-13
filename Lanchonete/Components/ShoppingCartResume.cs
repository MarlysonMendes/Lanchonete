using Lanchonete.Models;
using Lanchonete.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Components
{
    public class ShoppingCartResume : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartResume(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            //var itens = _shoppingCart.GetItensCart();
            var itens = new List<ShoppingCartItem>()
            {
                new ShoppingCartItem(),
                new ShoppingCartItem()

            };
            _shoppingCart.ShoppingCartItems = itens;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                TotalCartShopping = _shoppingCart.GetTotalAmountShoppingCart()
            };

            return View(shoppingCartViewModel);
        }
    }
}
