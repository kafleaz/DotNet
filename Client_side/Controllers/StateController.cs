using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Client_side.Controllers
{
    public class StateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetCookie(string data)
        {
            // Set a cookie with the user-provided data
            CookieOptions option = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30) // Cookie expiration time
            };
            Response.Cookies.Append("UserData", data, option);
            return RedirectToAction("GetCookie");
        }

        public IActionResult GetCookie()
        {
            // Retrieve the user data from the cookie
            string userData = Request.Cookies["UserData"];
            ViewBag.UserData = userData;
            return View();
        }
    }
}
