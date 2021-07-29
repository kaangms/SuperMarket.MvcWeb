 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using SuperMarket.Business.Abstract;
using SuperMarket.Entities.Concrete;
using SuperMarket.MvcWebUI.Models;

namespace SuperMarket.MvcWebUI.Controllers
{

    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [Authorize]
        public IActionResult Index()
        {
            ViewBag.ResultAddBasketStatus = "deneme";
            var model = new ProductListViewModel
            {
                Products = _productService.GetList()
            };

            return View(model);
        }
        [Authorize]
        public IActionResult GetList()
        {
            var model = new ProductListViewModel
            {
                Products = _productService.GetList()
            }.Products;
            if (model.Success)
            {
                return Ok(model.Data);
            }

            return BadRequest(model.Message);
        }


        public IActionResult AddProduct(int productId)
        {
            
            ViewBag.ResultStatus = "";
            //ViewBag.ResultMessages = "";

            return View(new ProductViewModel());
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            var result = _productService.Add(product);

            ViewBag.ResultStatus = result.Success;
            //ViewBag.ResultMessages = result.Message;
            return RedirectToAction("AddProduct", "Product");

        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
   
        public IActionResult UpdateProduct(int productId)
        {
            var model = new ProductViewModel
            {
                Product = _productService.GetById(productId).Data
            };

            return View(model);
            //return RedirectToAction("UpdateProduct", "Product");
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
           _productService.Update(product);

          
            return RedirectToAction("Index", "Product");

        }

        public IActionResult RemoveProduct(int productId)
        {
            var product = _productService.GetById(productId).Data;
            _productService.Remove(product);
            return RedirectToAction("Index", "Product");
        }
    }
}
