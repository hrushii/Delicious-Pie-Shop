using DeliciousPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeliciousPieShop.Pages
{
    public class CheckoutPageModel : PageModel
    {
        public CheckoutPageModel(IOrderRepository orderRepository,IShoppingCart shoppingCart)
        {
            OrderRepository = orderRepository;
            ShoppingCart = shoppingCart;
        }

        [BindProperty]
        public Order Order { get; set; }
        public IOrderRepository OrderRepository { get; }
        public IShoppingCart ShoppingCart { get; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            var items = ShoppingCart.GetShoppingCartItems();
            ShoppingCart.ShoppingCartItems = items;
            if(ShoppingCart.ShoppingCartItems.Count ==  0)
            {
                ModelState.AddModelError("", "Please add some pies first");
            }
            if(ModelState.IsValid)
            {
                OrderRepository.CreateOrder(Order);
                ShoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage"); ;
            }
            return Page();

        }
    }
}
