using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.Entities.Concrete;
using SuperMarket.MvcWebUI.Models;

namespace SuperMarket.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetList()
            };

            return View(model);
        }


        [Authorize]
        public IActionResult AddProduct()
        {
            return View(new ProductViewModel());
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);
            var addProduct = ErrorAddOrUpdateProduct(product, result);
            if (addProduct != null) return addProduct;
            TempData["message"] = result.Message;
            return RedirectToAction("AddProduct", "Product");
        }

        [Authorize]
        public IActionResult UpdateProduct(int productId)
        {
            var model = new ProductViewModel
            {
                Product = _productService.GetById(productId).Data
            };

            return View(model);
            //return RedirectToAction("UpdateProduct", "Product");
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            var result = _productService.Update(product);
            var updateProduct = ErrorAddOrUpdateProduct(product, result);
            if (updateProduct != null) return updateProduct;

            return RedirectToAction("Index", "Product");
        }

        private IActionResult ErrorAddOrUpdateProduct(Product product, IResult result)
        {
            if (!result.Success)
            {
                var model = new ProductViewModel {Product = product};
                TempData["message"] = result.Message;
                return View(model);
            }

            return null;
        }

        [Authorize]
        public IActionResult RemoveProduct(int productId)
        {
            var result = _productService.RemoveByProductId(productId);
            TempData["message"] = result.Message;
            return RedirectToAction("Index", "Product");
        }
    }
}