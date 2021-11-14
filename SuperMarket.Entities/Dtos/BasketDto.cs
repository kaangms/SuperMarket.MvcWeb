using System.Collections.Generic;
using Core.Entities.Abstract;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.Entities.Dtos
{
    public class BasketDto : IDto
    {
        public Basket Basket { get; set; }
        public BasketDetail BasketDetail { get; set; }
        public Product Product { get; set; }
    }

}