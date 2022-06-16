using Lanchonete.Models;
using Lanchonete.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IOrderRepository orderRepository, ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            int totalItens = 0;
            decimal priceTotal = 0.0m;
            //obter itens do carrinho de compra do cliente
            List<ShoppingCartItem> items = _shoppingCart.GetItensCart();
            _shoppingCart.ShoppingCartItems = items;
            //verificar se tem intens para pedir
            if(_shoppingCart.ShoppingCartItems.Count == 0)
                ModelState.AddModelError("", "Seu Carrinho esta vazio");

            // calcula o total de itens e total do pedido
            foreach(var item in items)
            {
                totalItens += item.Amount;
                priceTotal += (item.Lunch.Price * item.Amount);
            }

            //atribui os valores obtidos ao pedido
            order.TotalItensOrder = totalItens;
            order.TotalOrder = priceTotal;

            //valida os dados do pedido
            if(ModelState.IsValid)
            {
                //cria o pedido e os detalhes
                _orderRepository.CreateOrder(order);

                //define mensagens ao cliente
                ViewBag.CheckoutCompleteMenssage = "Obrigado pelo seu pedido";
                ViewBag.TotalOrder = _shoppingCart.GetTotalAmountShoppingCart();

                //limpa carrinho
                _shoppingCart.ClearShoppingCart();
                //exibe a view com dados do cliente e do pedido
                return View("~/Views/Orders/CheckoutComplete.cshtml",order);
            }
        //se tiver erro retorno a view com os erros do usuario
            return View(order);
        }
    }
}
