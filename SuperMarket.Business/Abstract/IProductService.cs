using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;
using System.Collections.Generic;

namespace SuperMarket.Business.Abstract
{
    public interface IProductService
    {
        IDataResult<Product> GetById(int productId);

        IDataResult<List<Product>> GetList();

        IResult Add(Product product);

        IResult Remove(Product product);
        IResult RemoveByProductId(int productId);

        IResult Update(Product product);
    }
}