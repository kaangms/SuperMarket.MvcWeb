using Core.Utilities.Results;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Constants;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IBasketService _basketService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IUnitOfWork _unitOfWork;

        public OrderManager(IUnitOfWork unitOfWork, IBasketService basketService, IOrderDetailService orderDetailService)
        {
            _unitOfWork = unitOfWork;
            _basketService = basketService;
            _orderDetailService = orderDetailService;
        }

        public IDataResult<Order> AddOrder(Order order)
        {
            var newOrder = _unitOfWork.OrderDal.Add(order);
            return new SuccessDataResult<Order>(newOrder.Entity);
        }

        public IResult CreateOrderByBasket(int userId, short paymentType)
        {
            var basket = CreateOrderByBasketId(userId, paymentType, out var order);
            _orderDetailService.CreateOrderDetailByOrder(order);
            basket.BasketStatus = false;
            _basketService.UpdateBasket(basket);
            _unitOfWork.SaveChanges();
            return new SuccessResult(Messages.SuccessOrderCreated);
        }

        private Basket CreateOrderByBasketId(int userId, short paymentType, out Order order)
        {
            var basket = _basketService.GetWaitingBasket(userId).Data;
            order = new Order
            {
                BasketId = basket.Id,
                UserId = basket.UserId,
                PaymentType = paymentType
            };
            order = AddOrder(order).Data;
            _unitOfWork.SaveChanges();
            return basket;
        }
    }
}