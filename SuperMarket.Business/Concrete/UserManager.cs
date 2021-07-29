using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Constants;
using SuperMarket.DataAccess.Abstract;

namespace SuperMarket.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IDataResult<User> GetByUser(string userName, string password)
        {
            var user = _unitOfWork.UserDal.Get(u => u.UserName == userName);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (user.Password!=password)
            {
                return new ErrorDataResult<User>(Messages.UserPasswordError);
            }
            return new SuccessDataResult<User>(user);
        }


    }
}
