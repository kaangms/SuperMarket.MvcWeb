using Core.DataAccess;
using Core.Entities.Concrete;

namespace SuperMarket.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}