using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.MvcWebUI.Models;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;

namespace SuperMarket.MvcWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly IBasketDetailService _basketDetailService;
        private readonly User _user;


        public BasketController(IBasketService basketService, IUserSessionService userSessionService, IBasketDetailService basketDetailService)
        {
            _basketService = basketService;
            _user = userSessionService.GetUser();
            _basketDetailService = basketDetailService;
        }
        [Authorize]
        public IActionResult AddToBasket(int productId)
        {
         
            var result = _basketService.AddAndReturnBasketResult(_user.Id, productId);
            TempData["MyActionResultModalMessage"] = result.Message;
            return RedirectToAction("Index", "Product");
        }
        [Authorize]
        public IActionResult RemoveToBasketDetail(int basketDetailId)
        {
            var result = _basketService.RemoveProductFromBasket(basketDetailId);
            TempData["message"] = result.Message;
            return RedirectToAction("Index", "Basket");
        }
        [Authorize]
        public IActionResult Index()
        {
         
            var basketDtos = _basketService.GetListBasketDto(_user.Id).Data;

            var model = new BasketViewModel()
            {
                BasketDtos = basketDtos
            };

            return View(model);
        }
    }
}