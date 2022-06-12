using Lanchonete.Models;
using Lanchonete.Repositories.Interfaces;
using Lanchonete.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILunchRepository _lunchRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ILunchRepository lunchRepository,
            ShoppingCart shoppingCart)
        {
            _lunchRepository = lunchRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            var itens = _shoppingCart.GetItensCart();
            _shoppingCart.ShoppingCartItems = itens;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                TotalCartShopping = _shoppingCart.GetTotalAmountShoppingCart()
            };

            return View(shoppingCartViewModel);
        }
        public IActionResult AddItemToShoppingCart(int lunchId)
        {
            var lunchSelect = _lunchRepository.Lunches
                                    .FirstOrDefault(p => p.LuchId == lunchId);

            if (lunchSelect != null)
            {
                _shoppingCart.AddItemShoppingCart(lunchSelect);
            }
            return RedirectToAction("Index");
        }

        public IActionResult RemoveItemToShoppingCart(int lunchId)
        {
            var lunchSelect = _lunchRepository.Lunches
                                    .FirstOrDefault(p => p.LuchId == lunchId);

            if (lunchSelect != null)
            {
                _shoppingCart.RemoveItemShoppingCart(lunchSelect);
            }
            return RedirectToAction("Index");
        }
    }
}