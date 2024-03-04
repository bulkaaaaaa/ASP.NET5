using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace WebApplication5.Controllers
{
    public class CheckCookiesController : Controller
    {
        public IActionResult Index()
        {
            if (Request.Cookies.ContainsKey("myValue"))
            {
                string myValue = Request.Cookies["myValue"];
                ViewData["Message"] = $"Значення в Cookies: {myValue}";
            }
            else
            {
                ViewData["Message"] = "Значення в Cookies відсутнє.";
            }

            return View();
        }
    }
}
