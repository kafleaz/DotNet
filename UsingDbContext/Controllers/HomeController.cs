using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using UsingDbContext.Models;

namespace PurpleStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationContext _context)
        {
            _logger = logger;
            context = _context;
        }

        public void Add()
        {
            var cat1 = new Category { Name = "Toy", Description = "This is a Car Toy!" };
            context.Categories.Add(cat1);
            context.SaveChanges();
            _logger.LogInformation("Category added: {@cat1}", cat1);
        }

        public IActionResult Index()
        {
            Add();  // Ensure this is called to add data
            List<Category> categorylist = context.Categories.ToList();
            return View(categorylist);
        }
    }
}
