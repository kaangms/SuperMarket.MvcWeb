using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<Order> AddOrder(Order order);

        IResult CreateOrderByBasket(int userId, short paymentType);
    }
}