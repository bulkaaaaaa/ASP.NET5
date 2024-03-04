using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetCookies(string myValue, DateTime expirationDate)
        {
            Response.Cookies.Append("myValue", myValue, new CookieOptions
            {
                Expires = expirationDate,
                HttpOnly = true
            });

            TempData["MyValue"] = myValue;

            await Task.Delay(1);

            return RedirectToAction("CheckCookies");
        }

        public IActionResult CheckCookies()
        {
            if (TempData.ContainsKey("MyValue"))
            {
                string myValue = TempData["MyValue"] as string;
                ViewData["Message"] = $"Значення в Cookies: {myValue}";
            }
            else
            {
                ViewData["Message"] = "Кука не встановлена.";
            }

            return View();
        }
    }
}
