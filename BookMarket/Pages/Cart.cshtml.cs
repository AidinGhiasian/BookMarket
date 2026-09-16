using BookM.Application.Contracts.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.WebEncoders.Testing;
using Nancy.Json;

namespace BookMarket.Pages
{
    public class CartModel : PageModel
    {
        public List<CartItem>? CartItems { get; set; }

        public const string CookieName = "cart-items";
        private readonly JavaScriptSerializer _serializer = new();
        public void OnGet()
        {

          
            CartItems = ReadCartItems();

            foreach (var item in CartItems)
            {
                item.TotalPrice = item.Price * item.Count;
            }
          
        }
        // حذف یک محصول از سبد خرید
        [ValidateAntiForgeryToken]
        public IActionResult OnPostRemoveitemFromCart(long id)
        {
            var cartItems = ReadCartItems();

            // فقط محصول موردنظر حذف می‌شود
            cartItems.RemoveAll(item => item.Id == id);

            // کوکی با لیست جدید ذخیره می‌شود
            SaveCartItems(cartItems);

            return RedirectToPage();
        }
        private List<CartItem> ReadCartItems()
        {
            var cookieValue = Request.Cookies[CookieName];

            if (string.IsNullOrWhiteSpace(cookieValue))
            {
                return new List<CartItem>();
            }

            try
            {
                return _serializer.Deserialize<List<CartItem>>(cookieValue)
                       ?? new List<CartItem>();
            }
            catch
            {
                // اگر کوکی خراب یا نامعتبر بود
                return new List<CartItem>();
            }
        }

        private void SaveCartItems(List<CartItem> cartItems)
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(2),
                Path = "/",

                // چون JavaScript هم باید کوکی را بخواند، HttpOnly نباشد
                HttpOnly = false,

                SameSite = SameSiteMode.Lax,
                Secure = Request.IsHttps,
                IsEssential = true
            };

            Response.Cookies.Append(
                CookieName,
                _serializer.Serialize(cartItems),
                cookieOptions
            );
        }

    }
}