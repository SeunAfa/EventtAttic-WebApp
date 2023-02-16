using EventAttic.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace EventAttic.Data.ViewComponents
{
    public class ShoppingCartIcon : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartIcon(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        //Invoke Method
        public IViewComponentResult Invoke()
        {
            var ShoppincartItems = _shoppingCart.GetShoppingCartItems();
            return View(ShoppincartItems.Count);
        }
    }
}
