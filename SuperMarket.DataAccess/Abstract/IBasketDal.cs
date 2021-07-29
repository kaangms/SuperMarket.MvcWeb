using System.Collections.Generic;
using Core.DataAccess;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;


namespace SuperMarket.DataAccess.Abstract
{
    public interface IBasketDal : IEntityRepository<Basket>
    {
        List<BasketDto> GetListBasketDto(int userId);
    }
}