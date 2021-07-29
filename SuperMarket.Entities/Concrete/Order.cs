using Core.Entities;
using Core.Entities.Abstract;

namespace SuperMarket.Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BasketId { get; set; }
        public short PaymentType { get; set; }
    }
}
