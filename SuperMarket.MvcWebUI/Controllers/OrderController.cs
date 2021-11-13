using Microsoft.AspNetCore.Mvc;
using SuperMarket.Business.Abstract;
using SuperMarket.MvcWebUI.Services.SessionService.Abstract;

namespace SuperMarket.MvcWebUI.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;
        private IUserSessionService _userSessionService;

        public OrderController(IOrderService orderService, IUserSessionService userSessionService)
        {
            _orderService = orderService;
            _userSessionService = userSessionService;
        }

        public IActionResult CreateOrder(short paymentType)
        {
            var user = _userSessionService.GetUser().User;
            _orderService.CreateOrderByBasket(user.Id, paymentType);

            return RedirectToAction("Index", "Product");
        }
    }
}