using Core.DataAccess;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.DataAccess.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
    }
}