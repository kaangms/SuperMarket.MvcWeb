using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SuperMarket.Business.Abstract;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.MvcWebUI.Models;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;

namespace SuperMarket.MvcWebUI.Controllers
{
    public class BasketController : Controller
    {
       private IBasketService _basketService;
        private IUserSessionService _userSessionService;
        private IBasketDetailService _basketDetailService;



        public BasketController(IBasketService basketService, IUserSessionService userSessionService, IBasketDetailService basketDetailService)
        {
            _basketService = basketService;
        
            _userSessionService = userSessionService;
            _basketDetailService = basketDetailService;
        }


        public IActionResult AddToBasket(int productId)
        {
         
            ViewBag.ResultAddBasketStatus = "";
            var user = _userSessionService.GetUser().User;
           var result= _basketService.AddBasket(user.Id, productId);
            ViewBag.ResultAddBasketStatus = result.Success;
   

            return RedirectToAction("Index", "Product");
        }
        public IActionResult RemoveToBasketDetail(int basketDetailId)
        {
            var user = _userSessionService.GetUser().User;
            _basketDetailService.RemoveFromBasketDetail(basketDetailId);
            var basket = _basketService.GetBasket(user.Id).Data;
            var basketDetails = _basketDetailService.GetBasketDetailList(basket.Id).Data;
            _basketService.UpdateBasket(basket, basketDetails);
            return RedirectToAction("Index", "Basket");
        }

        public IActionResult Index()
        {
            var user = _userSessionService.GetUser().User;
            var basketDtos = _basketService.GetListBasketDto(user.Id).Data;

            var model=new BasketViewModel()
            {
                BasketDtos = basketDtos
            };


            return View(model);
        }

       
    }
}
