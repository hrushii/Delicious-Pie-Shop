using DeliciousPieShop.Models;
using DeliciousPieShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DeliciousPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            PieRepository = pieRepository;
            ShoppingCart = shoppingCart;
        }

        public IPieRepository PieRepository { get; }
        public IShoppingCart ShoppingCart { get; }

        public IActionResult Index()
        {
            var items = ShoppingCart.GetShoppingCartItems();
            ShoppingCart.ShoppingCartItems = items;
            var cartTotal = ShoppingCart.GetShoppingCartTotal();

            var shoppingCartViewModel = new ShoppingCartViewModel( ShoppingCart,cartTotal);
            var i = shoppingCartViewModel.ShoppingCart.GetShoppingCartItems();
            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(int pieId)
        {
            Pie? selectedPie = PieRepository.GetPieById(pieId);
            ShoppingCart.AddToCart(selectedPie);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromShoppingCart(int pieId)
        {
            Pie? selectedPie = PieRepository.GetPieById(pieId);
            if(selectedPie != null)
            {
                ShoppingCart?.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
