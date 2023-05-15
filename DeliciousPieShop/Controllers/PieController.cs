using Microsoft.AspNetCore.Mvc;
using DeliciousPieShop.Models;
using DeliciousPieShop.ViewModel;

namespace DeliciousPieShop.Controllers
{
    public class PieController : Controller
    {
        public readonly IPieRepository _pieRepository;
        public ICategoryRepository _categoryRepository { get; }

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Cheese cakes";
        //    //return View(_pieRepository.AllPies);

        //    var pieListModel = new PieListViewModel(_pieRepository.AllPies, "All pies");
        //    return View(pieListModel);
        //}
        public IActionResult List(string category)
        {
            IEnumerable<Pie> Pies;
            string? currentCategory;
            if(string.IsNullOrEmpty(category))
            {
                Pies = _pieRepository.AllPies.OrderBy(p => p.Category).ToList();
                currentCategory = "All Pies";
            }
            else
            {
                Pies = _pieRepository.AllPies.Where(x => x.Category.CategoryName == category).OrderBy(p => p.PieId);
                currentCategory = _categoryRepository?.AllCategories?.FirstOrDefault(x => x.CategoryName == category).CategoryName;
            }
            var listviewModel = new PieListViewModel(Pies, currentCategory);
            return View(listviewModel);

        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
