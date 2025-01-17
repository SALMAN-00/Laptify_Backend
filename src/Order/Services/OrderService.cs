using AutoMapper;
namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderItemRepository orderItemRepository, IProductRepository productRepository, IOrderRepository orderReposiroty, IMapper mapper)
        {
            _mapper = mapper;
            _orderRepository = orderReposiroty;
            _productRepository = productRepository;
            _orderItemRepository = orderItemRepository;
        }
        public IEnumerable<OrderReadDto> FindAll()
        {
            var orders = _orderRepository.FindAll();
            var ordersRead = orders.Select(_mapper.Map<OrderReadDto>);
            return ordersRead;
        }
        public OrderReadDto? FindOne(Guid orderId)
        {
            Order? order = _orderRepository.FindOne(orderId);
            OrderReadDto? orderRead = _mapper.Map<OrderReadDto>(order);
            return orderRead;
        }
        public OrderReadDto CreateOne(OrderCreateDto order)
        {
            var newProduct = _mapper.Map<Order>(order);
            var createdOrder = _orderRepository.CreateOne(newProduct);
            var orderRead = _mapper.Map<OrderReadDto>(createdOrder);
            return orderRead;
        }
        public OrderReadDto Checkout(CheckoutDto checkoutList, string userId)
        {
            double totalPrice = 0;
            var order = new Order();
            order.AddressId = checkoutList.AddressId;
            order.UserId = new Guid(userId);
            order.Status = Status.Processing;
            var createdOrder = _orderRepository.CreateOne(order);
            foreach (var orderCheckout in checkoutList.Items!)
            {
                var product = _productRepository.FindOne(orderCheckout.ProductId);
                if (product is null) continue;
                if (product.Stock >= orderCheckout.Quantity)
                {
                    product.Stock -= orderCheckout.Quantity;
                    _productRepository.UpdateStock(product);
                    var orderItem = new OrderItem();
                    orderItem.ProductId = product.Id;
                    orderItem.OrderId = order.Id;
                    orderItem.Quantity = orderCheckout.Quantity;
                    orderItem.TotalPirce = (product.Price * orderCheckout.Quantity);
                    _orderItemRepository.CreateOne(orderItem);
                    totalPrice += orderItem.TotalPirce;
                }
            }
            order.TotalPrice = totalPrice;
            _orderRepository.UpdateOne(order);
            var orderRead = _mapper.Map<OrderReadDto>(createdOrder);
            return orderRead;
        }

        public OrderReadDto? UpdateOne(Guid id, Order newOrder)
        {
            Order? updatedOrder = _orderRepository.FindOne(id);
            if (updatedOrder is not null)
            {
                updatedOrder.Status = newOrder.Status;

                var updatedOrderAllInfo = _orderRepository.UpdateOne(updatedOrder);
                var updatedOrderRead = _mapper.Map<OrderReadDto>(updatedOrderAllInfo);
                return updatedOrderRead;
            }
            else return null;
        }

        public bool DeleteOne(Guid id)
        {
            return _orderRepository.DeleteOne(id);
        }
    }
}