using BookM.Application.Contracts.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using System.Xml.Linq;

namespace BookMarket.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem>? CartItems { get; set; }

        public const string CookieName = "cart-items";

        public void OnGet()
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            CartItems = serializer.Deserialize<List<CartItem>>(value) ?? new List<CartItem>();

            foreach (var item in CartItems)
            {
                item.TotalPrice = item.Price * item.Count;
            }
        }

        public IActionResult OnGetRemoveFromCart(long id)
        {
            var serializer = new JavaScriptSerializer();
            var value = Request.Cookies[CookieName];

            var cartItems = serializer.Deserialize<List<CartItem>>(value);

            var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);

            cartItems.Remove(itemToRemove);

            var newValue = serializer.Serialize(cartItems);

            Response.Cookies.Delete(CookieName, new CookieOptions
            {
                Path = "/"
            });

            Response.Cookies.Append(CookieName, newValue, new CookieOptions
            {
                Expires = DateTime.Now.AddDays(2),
                Path = "/"
        });

            return RedirectToPage();
        }
    }
}