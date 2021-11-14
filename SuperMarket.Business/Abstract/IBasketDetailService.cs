using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;
using System.Collections.Generic;

namespace SuperMarket.Business.Abstract
{
    public interface IBasketDetailService
    {
        IDataResult<List<BasketDetail>> GetBasketDetailList(int basketId);

        IDataResult<BasketDetail> GetBasket(int basketDetailId);

        IDataResult<BasketDetail> GetBasket(int productId, int basketId);

        IDataResult<List<BasketDetail>> AddToBasketDetail(int productId, int basketId);

        IResult RemoveFromBasketDetail(int basketDetailId);
    }
}