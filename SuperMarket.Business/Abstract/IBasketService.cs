using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;
using System.Collections.Generic;
using SuperMarket.Entities.Dtos;


namespace SuperMarket.Business.Abstract
{
    public interface IBasketService
    {
        IDataResult <Basket> GetBasket(int userId);
 
        IResult AddBasket(int userId, int productId);
        IDataResult<Basket> CheckBasket(int userId);
        IDataResult<Basket> AddBasketToUser(int userId);
        IResult UpdateBasket(Basket basket, List<BasketDetail> basketDetail);
        IResult UpdateBasket(Basket basket);

        IDataResult<List<BasketDto>> GetListBasketDto(int userId);

    }
}