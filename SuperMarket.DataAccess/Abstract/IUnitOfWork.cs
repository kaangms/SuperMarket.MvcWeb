using System;

namespace SuperMarket.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable

    {
        IBasketDal BasketDal { get; }
        IBasketDetailDal BasketDetailDal { get; }
        IOrderDal OrderDal { get; }
        IOrderDetailDal OrderDetailDal { get; }
        IProductDal ProductDal { get; }
        IUserDal UserDal { get; }

        bool SaveChanges();
    }
}