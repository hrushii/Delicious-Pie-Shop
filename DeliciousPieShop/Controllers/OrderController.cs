using DeliciousPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeliciousPieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public OrderController(IOrderRepository orderRepository,IShoppingCart shoppingCart)
        {
            OrderRepository = orderRepository;
            ShoppingCart = shoppingCart;
        }

        public IOrderRepository OrderRepository { get; }
        public IShoppingCart ShoppingCart { get; }

        //[HttpGet] -> it is default
        public IActionResult CheckOut()//Get
        {
            return View();
        }

        [HttpPost]//attribute
        public IActionResult Checkout(Order order)
        {
            var cartItems=  ShoppingCart.GetShoppingCartItems();
            ShoppingCart.ShoppingCartItems=cartItems;
            if(cartItems.Count == 0)
            {
                ModelState.AddModelError("","Your Cart Is Emty. Please Add SOme Pies First");
            }
            if(ModelState.IsValid)
            {
                OrderRepository.CreateOrder(order);
                ShoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }



        public IActionResult CheckoutComplete()
        {
            ViewBag.CompleteCheckout = "Thank you for your order!!";
            return View();
        }
    }
}
