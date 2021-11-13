using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
    public class EfBasketDetailDal : EfEntityRepositoryBase<BasketDetail>, IBasketDetailDal
    {
        public EfBasketDetailDal(DbContext context) : base(context)
        {
        }
    }
}