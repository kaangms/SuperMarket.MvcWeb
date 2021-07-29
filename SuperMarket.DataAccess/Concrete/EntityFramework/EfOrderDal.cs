using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.DataAccess.Concrete.EntityFramework.Contexts;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order>, IOrderDal
    {
        public EfOrderDal(DbContext context) : base(context)
        {
        }
    }
}