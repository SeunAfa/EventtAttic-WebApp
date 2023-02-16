using EventAttic.Models;
using Microsoft.EntityFrameworkCore;

namespace EventAttic.Data.Cart
{
    public class ShoppingCart
    {
        public ApplicationDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(ApplicationDbContext context)
        {
            _context = context;
        }

        public static ShoppingCart GetShoppingCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();

            string shoppingCartId = session.GetString("ShoppingCartId") ?? Guid.NewGuid().ToString();
            session.SetString("ShoppingCartId", shoppingCartId);

            return new ShoppingCart(context) { ShoppingCartId = shoppingCartId };

        }

        public void AddItemToShoppingCart(Event @event)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Event.Id == @event.Id &&
            n.ShoppingCartId == ShoppingCartId);

            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Event = @event,
                    Amount = 1
                };

                _context.ShoppingCartItems.Add(ShoppingCartItem);
            }
            else
            {
                ShoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Event @event)
        {
            var ShoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Event.Id == @event.Id &&
                        n.ShoppingCartId == ShoppingCartId);

            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                }
                else
                {
                    _context.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _context.ShoppingCartItems.Where(n => n.ShoppingCartId
            == ShoppingCartId).Include(n => n.Event).ToList());
        }

        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(
                n => n.Event.Price * n.Amount).Sum();
            return (double)total;
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).ToListAsync();
            _context.ShoppingCartItems.RemoveRange(items);
            await _context.SaveChangesAsync();

            ShoppingCartItems = new List<ShoppingCartItem>();

        }
    }
}
