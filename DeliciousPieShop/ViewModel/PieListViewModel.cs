using DeliciousPieShop.Models;

namespace DeliciousPieShop.ViewModel
{
    public class PieListViewModel
    {
        public PieListViewModel(IEnumerable<Pie> pies, string currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
        public IEnumerable<Pie> Pies { get; }
        public string CurrentCategory { get; }
    }
}
