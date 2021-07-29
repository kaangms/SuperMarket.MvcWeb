using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using SuperMarket.DataAccess.Abstract;

namespace SuperMarket.DataAccess.Concrete.EntityFramework
{
  public  class EfUserDal:EfEntityRepositoryBase<User>,IUserDal
    {
        public EfUserDal(DbContext context) : base(context)
        {
        }
    }
}
