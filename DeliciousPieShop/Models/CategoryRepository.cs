namespace DeliciousPieShop.Models
{
    public class CategoryRepository: ICategoryRepository
    {
        public CategoryRepository(DeliciousPieShopDbContext deliciousPieShopDbContext)
        {
            DeliciousPieShopDbContext = deliciousPieShopDbContext;
        }

        public DeliciousPieShopDbContext DeliciousPieShopDbContext { get; }

        public IEnumerable<Category> AllCategories
        {
            get
            {
                return DeliciousPieShopDbContext.Categories;
            }
        }
    }
}
