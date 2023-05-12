using Microsoft.AspNetCore.Mvc;
using DeliciousPieShop.Models;
using DeliciousPieShop.ViewModel;

namespace DeliciousPieShop.Controllers
{
    public class PieController : Controller 
    {
        public readonly IPieRepository _pieRepository;
        public ICategoryRepository _categoryRepository { get; }

        public PieController(IPieRepository pieRepository,ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese cakes";
            //return View(_pieRepository.AllPies);

            var pieListModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(pieListModel);
        }
    }
}
