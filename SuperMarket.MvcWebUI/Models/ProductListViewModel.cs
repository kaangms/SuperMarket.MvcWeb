using Core.Utilities.Results;
using SuperMarket.Entities.Concrete;
using System.Collections.Generic;

namespace SuperMarket.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public IDataResult<List<Product>> Products { get; set; }
    }
}