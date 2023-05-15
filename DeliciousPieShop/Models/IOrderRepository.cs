namespace DeliciousPieShop.Models
{
    public interface IOrderRepository
    {
        public void CreateOrder(Order order);
    }
}
