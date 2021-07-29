using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.Business.Abstract;
using SuperMarket.Entities.Concrete;
using SuperMarket.Entities.Dtos;

namespace SuperMarket.MvcWebUI.Models
{
    public class BasketViewModel
    {
       public List<BasketDto> BasketDtos { get; set; }
    }
}
