using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);

        IDataResult<List<Product>> GetList();
     
        IResult Add(Product product);
        IResult Remove(Product product);
        IResult Update(Product product);
    }
}
