namespace DeliciousPieShop.Models
{
    public class PieRepository : IPieRepository
    {
        public PieRepository(DeliciousPieShopDbContext deliciousPieShopDbContext)
        {
            _deliciousPieShopDbContext = deliciousPieShopDbContext;
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
    }
}
