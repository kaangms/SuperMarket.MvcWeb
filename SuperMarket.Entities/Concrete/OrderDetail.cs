using Core.Entities;
using Core.Entities.Abstract;

namespace SuperMarket.Entities.Concrete
{
    public class OrderDetail : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int BasketDetailId { get; set; }
    }
}
