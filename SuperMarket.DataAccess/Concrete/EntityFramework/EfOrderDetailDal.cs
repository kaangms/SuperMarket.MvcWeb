using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.DataAccess.Concrete.EntityFramework.Contexts;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDetailDal : EfEntityRepositoryBase<OrderDetail>, IOrderDetailDal
    {
        public EfOrderDetailDal(DbContext context) : base(context)
        {
        }
    }
}