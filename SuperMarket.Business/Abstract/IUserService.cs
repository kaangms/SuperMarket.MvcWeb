using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace SuperMarket.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetByUser(string userName, string password);
    }
}