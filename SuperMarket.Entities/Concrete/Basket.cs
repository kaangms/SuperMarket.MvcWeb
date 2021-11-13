using Core.Entities.Abstract;

namespace SuperMarket.Entities.Concrete
{
    public class Basket : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductCount { get; set; }
        public decimal TotalPrice { get; set; }
        public bool BasketStatus { get; set; }
    }
}