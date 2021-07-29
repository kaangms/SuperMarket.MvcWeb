using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using SuperMarket.Business.Abstract;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private IUnitOfWork _unitOfWork;
        private IBasketDetailService _basketDetailService;

        public OrderDetailManager(IUnitOfWork unitOfWork, IBasketDetailService basketDetailService)
        {
            _unitOfWork = unitOfWork;
            _basketDetailService = basketDetailService;
        }

        public IResult AddOrderDetail(OrderDetail orderDetail)
        {
            _unitOfWork.OrderDetailDal.Add(orderDetail);
            return new SuccessResult();
        }

        public IResult CreateOrderDetailByOrder(Order order)
        {
            var basketDetails = _basketDetailService.GetBasketDetailList(order.BasketId).Data;

            foreach (var basketDetail in basketDetails)
            {
                var orderDetail = new OrderDetail()
                {
                    BasketDetailId = basketDetail.Id,
                    OrderId = order.Id
                };
                AddOrderDetail(orderDetail);
            }

            _unitOfWork.SaveChanges();
            return new SuccessResult();
        }
    }
}
