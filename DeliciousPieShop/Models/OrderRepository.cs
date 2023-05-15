namespace DeliciousPieShop.Models
{
    public class OrderRepository : IOrderRepository
    {
        public OrderRepository(DeliciousPieShopDbContext deliciousPieShopDbContext,IShoppingCart shoppingCart)
        {
            DeliciousPieShopDbContext = deliciousPieShopDbContext;
            ShoppingCart = shoppingCart;
        }

        public DeliciousPieShopDbContext DeliciousPieShopDbContext { get; }
        public IShoppingCart ShoppingCart { get; }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            var items = ShoppingCart.GetShoppingCartItems();
            order.OrderTotal = ShoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();

            foreach(var item in items)
            {
                var orderDetail = new OrderDetail();
                orderDetail.PieId = item.Pie.PieId;
                orderDetail.Amount = item.Amount;
                orderDetail.Price = item.Pie.Price;
                order.OrderDetails.Add(orderDetail);
            }

            DeliciousPieShopDbContext.Orders.Add(order);
            DeliciousPieShopDbContext.SaveChanges();
        }



    }
}
