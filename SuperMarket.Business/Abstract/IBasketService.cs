using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;
using System.Collections.Generic;

namespace SuperMarket.Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<Basket> GetWaitingBasket(int userId);
        IDataResult<List<BasketDto>> AddAndReturnBasketResult(int userId, int productId);
        IResult UpdateBasket(Basket basket, List<BasketDetail> basketDetail);

        IResult UpdateBasket(Basket basket);

        IDataResult<List<BasketDto>> GetListBasketDto(int userId);
        IResult RemoveProductFromBasket(int basketDetailId);
    }
}