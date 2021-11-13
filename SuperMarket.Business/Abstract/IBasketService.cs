using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;
using System.Collections.Generic;

namespace SuperMarket.Business.Abstract
{
    public interface IBasketService
    {
        IDataResult<Basket> GetBasket(int userId);

        IResult AddBasket(int userId, int productId);

        IDataResult<Basket> CheckBasket(int userId);

        IDataResult<Basket> AddBasketToUser(int userId);

        IResult UpdateBasket(Basket basket, List<BasketDetail> basketDetail);

        IResult UpdateBasket(Basket basket);

        IDataResult<List<BasketDto>> GetListBasketDto(int userId);
    }
}