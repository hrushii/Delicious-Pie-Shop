namespace DeliciousPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        public PieRepository(DeliciousPieShopDbContext deliciousPieShopDbContext)
        {
            _deliciousPieShopDbContext = deliciousPieShopDbContext;
            if(_deliciousPieShopDbContext.Database.EnsureCreated())
            {
                var vk = true;
            }
        }

        public DeliciousPieShopDbContext _deliciousPieShopDbContext { get; }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _deliciousPieShopDbContext.Pies;
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _deliciousPieShopDbContext.Pies.Where(x => x.IsPieOfTheWeek);
            }
        }

        public Pie? GetPieById(int pieId)
        {
            return _deliciousPieShopDbContext.Pies.First(x => x.PieId == pieId);
        }

        public IEnumerable<Pie> SearchPies(string searchQuery)
        {
            var pies = _deliciousPieShopDbContext.Pies.Where(p => p.Name.Contains(searchQuery));
            return pies;
        }
    }
}
