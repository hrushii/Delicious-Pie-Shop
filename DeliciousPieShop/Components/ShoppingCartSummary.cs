using DeliciousPieShop.Models;
using DeliciousPieShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DeliciousPieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        public ShoppingCartSummary(IShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
        }

        public IShoppingCart ShoppingCart { get; }

        public IViewComponentResult Invoke()
        {
            var items = ShoppingCart.ShoppingCartItems;
            ShoppingCart.ShoppingCartItems = items;
            var totalPrice = ShoppingCart.GetShoppingCartTotal();
            var shoppingCartViewModel = new ShoppingCartViewModel(ShoppingCart, totalPrice);
            return View(shoppingCartViewModel);
        }
    }
}
