using DeliciousPieShop.Models;

namespace DeliciousPieShop.ViewModel
{
    public class HomeViewModel
    {
        public HomeViewModel(IEnumerable<Pie> piesOftheWeek)
        {
            PiesOfTheWeek = piesOftheWeek;
        }

        public IEnumerable<Pie> PiesOfTheWeek { get; }
    }
}
