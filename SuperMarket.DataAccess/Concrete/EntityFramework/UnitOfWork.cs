using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.DataAccess.Concrete.EntityFramework.Contexts;

namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SuperMarketDbContext _superMarketDbContext;

        IBasketDal IUnitOfWork.BasketDal => new EfBasketDal(_superMarketDbContext,_superMarketDbContext);

        IBasketDetailDal IUnitOfWork.BasketDetailDal => new EfBasketDetailDal(_superMarketDbContext);

        IOrderDal IUnitOfWork.OrderDal =>new EfOrderDal(_superMarketDbContext);

        IOrderDetailDal IUnitOfWork.OrderDetailDal =>new EfOrderDetailDal(_superMarketDbContext);

        IProductDal IUnitOfWork.ProductDal =>new EfProductDal(_superMarketDbContext);
        public IUserDal UserDal => new EfUserDal(_superMarketDbContext);

        public UnitOfWork(SuperMarketDbContext superMarketDbContext)
        {
            _superMarketDbContext = superMarketDbContext;
        }

        
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