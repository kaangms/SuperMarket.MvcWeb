using SuperMarket.DataAccess.Abstract;
using SuperMarket.DataAccess.Concrete.EntityFramework.Contexts;
using System;

namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperMarketDbContext _superMarketDbContext;
        //public IBasketDal BasketDal { get; }
        //public IBasketDetailDal BasketDetailDal { get; }
        //public IOrderDal OrderDal { get; }
        //public IOrderDetailDal OrderDetailDal { get; }
        //public IProductDal ProductDal { get; }
        //public IUserDal UserDal { get; }

        public UnitOfWork(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
            //BasketDal = new EfBasketDal(_superMarketDbContext);
            //BasketDetailDal = new EfBasketDetailDal(_superMarketDbContext);
            //OrderDal = new EfOrderDal(_superMarketDbContext);
            //OrderDetailDal =new EfOrderDetailDal(_superMarketDbContext);
            //ProductDal = new EfProductDal(_superMarketDbContext);
            //UserDal = new EfUserDal(_superMarketDbContext);
        }

        IBasketDal IUnitOfWork.BasketDal => new EfBasketDal(_superMarketDbContext);

        IBasketDetailDal IUnitOfWork.BasketDetailDal => new EfBasketDetailDal(_superMarketDbContext);

        IOrderDal IUnitOfWork.OrderDal => new EfOrderDal(_superMarketDbContext);

        IOrderDetailDal IUnitOfWork.OrderDetailDal => new EfOrderDetailDal(_superMarketDbContext);

        IProductDal IUnitOfWork.ProductDal => new EfProductDal(_superMarketDbContext);
        public IUserDal UserDal => new EfUserDal(_superMarketDbContext);

        public bool SaveChanges()
        {
            return _superMarketDbContext.SaveChanges() > 0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool
            disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _superMarketDbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}