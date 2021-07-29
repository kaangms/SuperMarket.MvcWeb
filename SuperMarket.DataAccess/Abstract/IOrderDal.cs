using Core.DataAccess;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
    }
}