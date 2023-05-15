using DeliciousPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace DeliciousPieShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            CategoryRepository = categoryRepository;
        }

        public ICategoryRepository CategoryRepository { get; }

        public IViewComponentResult Invoke()
        {
            var categories = CategoryRepository.AllCategories.OrderBy(x=>x.CategoryName);
            return View(categories);
        }
    }
}
