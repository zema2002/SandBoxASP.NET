using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TypeOfProductContext db;
        public HomeController(TypeOfProductContext context,ILogger<HomeController>logger)
        {
            db = context;
            _logger = logger;
        }
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Restaurant()
        {
            return View(await db.Products.ToListAsync());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<ActionResult> RenderImage(int id)
        {
            Product item = await db.Products.FindAsync(id);

            byte[] photoBack = item.ProductPicture;

            return File(photoBack, "image/png");
        }
        public async Task<IActionResult> Shaurma(Guid id)
        {
            return View(await db.Restaurants.ToListAsync());
        }
    }
}
