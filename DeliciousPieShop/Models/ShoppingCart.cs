using Microsoft.EntityFrameworkCore;

namespace DeliciousPieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly DeliciousPieShopDbContext DeliciousPieShopDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(DeliciousPieShopDbContext bethanysPieShopDbContext)
        {
            DeliciousPieShopDbContext = bethanysPieShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            DeliciousPieShopDbContext context = services.GetService<DeliciousPieShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem =
                    DeliciousPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                DeliciousPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            DeliciousPieShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    DeliciousPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    DeliciousPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            DeliciousPieShopDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       DeliciousPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                          .Include(x=>x.Pie).ToList();
        }

        public void ClearCart()
        {
            var cartItems = DeliciousPieShopDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            DeliciousPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            DeliciousPieShopDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = DeliciousPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }
}
