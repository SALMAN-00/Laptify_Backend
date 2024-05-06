namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public interface IOrderService
    {
        public IEnumerable<OrderReadDto>FindAll();
        public IEnumerable<Order> CreateOne(Order userOrder);
        public Order? FindOneById(Guid id);
        public Order? UpdateOne(Guid id, Order.OrderStatus status);

    }
}