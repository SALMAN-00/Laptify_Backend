namespace sda_onsite_2_csharp_backend_teamwork_The_countryside_developers
{
    public class UserOrderService : IUserOrderService
    {
        private IUserOrderRepository _userOrderRepository;

        public UserOrderService(IUserOrderRepository userOrderRepository)
        {
            _userOrderRepository = userOrderRepository;
        }

        public IEnumerable<UserOrder> FindAll()
        {
            return _userOrderRepository.FindAll();
        }
        public IEnumerable<UserOrder> CreateOne(UserOrder userOrder)
        {
            UserOrder? FoundUserOrder = _userOrderRepository.FindOne(userOrder);
            if (FoundUserOrder is not null)
            {
                return null;
            }
            return _userOrderRepository.CreateOne(userOrder);
        }
        public UserOrder? FindOneById(string id)
        {
            return _userOrderRepository.FindOneById(id);
        }

    }
}