using DeliciousPieShop.Models;
using DeliciousPieShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace DeliciousPieShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPieRepository pieRepository)
        {
            PieRepository = pieRepository;
        }

        public IPieRepository PieRepository { get; }

        public IActionResult Index()
        {

            var piesOfTheWeek = PieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(piesOfTheWeek);
            return View(homeViewModel);
        }
    }
}
