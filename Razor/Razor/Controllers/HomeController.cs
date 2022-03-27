using Microsoft.AspNetCore.Mvc;
using Razor.Models;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Product[] products = {
                new Product {Name = "Kayak", Price = 275M },
                new Product {Name = "LifeJacket", Price = 48.95M },
                new Product {Name = "SoccerBall", Price = 19.50M },
                new Product {Name = "CornerFlag", Price = 34.95M },
            };

            return View(products);
        }
    }
}
