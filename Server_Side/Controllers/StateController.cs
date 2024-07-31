using Microsoft.AspNetCore.Mvc;

namespace Server_Side.Controllers
{
        public class StateController : Controller
        {
            public IActionResult Add()
            {
                return View();
            }

            [HttpPost]
            public IActionResult SetUserData(string username, string message)
            {           
                // Session state example 
                HttpContext.Session.SetString("Username", username);
                // TempData example 
                TempData["Message"] = message;
                return RedirectToAction("Display");
            }

            public IActionResult Display()
            {
                // Retrieve session state 
                string username = HttpContext.Session.GetString("Username");
                // Retrieve TempData 
                string message = TempData["Message"] as string;
                ViewBag.Username = username; ViewBag.Message = message;
                return View();
            }
        }

}
