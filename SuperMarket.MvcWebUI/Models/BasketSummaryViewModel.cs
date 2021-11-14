using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;

namespace SuperMarket.MvcWebUI.Models
{
    public class BasketSummaryViewModel
    {
        public Basket Basket { get; set; }
    }
}
