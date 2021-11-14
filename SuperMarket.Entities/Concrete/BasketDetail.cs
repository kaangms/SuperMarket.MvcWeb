using System;
using Core.Entities.Abstract;

namespace SuperMarket.Entities.Concrete
{
    public class BasketDetail : IEntity
    {
        public int Id { get; set; }
        public int BasketId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

      
    }
}