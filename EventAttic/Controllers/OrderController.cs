using EventAttic.Data.Cart;
using EventAttic.Data.Services;
using EventAttic.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EventAttic.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IEventService _eventService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;

        public OrderController(IEventService eventService, ShoppingCart shoppingCart, IOrderService orderService)
        {
            _eventService = eventService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var order = await _orderService.GetOrdersByUserIdAndRoleAsync(userId, userRole);
            return View(order);
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(response);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var getEvent_Item = await _eventService.GetEventByIdAsync(id);

            if (getEvent_Item != null)
            {
                _shoppingCart.AddItemToShoppingCart(getEvent_Item);
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> RemoveItemFromShoppingCart(int id)
        {
            var getEvent_Item = await _eventService.GetEventByIdAsync(id);

            if (getEvent_Item != null)
            {
                _shoppingCart.RemoveItemFromCart(getEvent_Item);
            }

            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();


            return View("OrderCompleted");

        }
    }
}
