using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;

namespace SuperMarket.MvcWebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private readonly User _user;

        public OrderController(IOrderService orderService, IUserSessionService userSessionService)
        {
            _orderService = orderService;
            _user = userSessionService.GetUser();
        }
        [Authorize]
        public IActionResult CreateOrder(short paymentType)
        {
         var result=  _orderService.CreateOrderByBasket(_user.Id, paymentType);
            TempData["MyActionResultModalMessage"] = result.Message;
            return RedirectToAction("Index", "Product");
        }
    }
}