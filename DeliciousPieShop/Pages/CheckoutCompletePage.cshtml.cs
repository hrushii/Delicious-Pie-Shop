using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DeliciousPieShop.Pages
{
    public class CheckoutCompleteModel : PageModel
    {
        public void OnGet()
        {
            ViewData["CheckoutCompleteMessage"] = "Thankyou for your order. You'll soon enjoy delicious pies";
        }
    }
}
