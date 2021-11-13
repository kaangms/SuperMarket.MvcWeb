using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.Business.Abstract
{
    public interface IOrderDetailService
    {
        IResult AddOrderDetail(OrderDetail orderDetail);

        IResult CreateOrderDetailByOrder(Order order);
    }
}