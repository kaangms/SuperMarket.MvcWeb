using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;

namespace SuperMarket.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public IDataResult<List<Product>> Products { get; set; }
    }
}
