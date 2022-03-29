using Microsoft.AspNetCore.Mvc;
using WorkingWithVisualStudio.Models;

namespace WorkingWithVisualStudio.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(SimpleRepository.ShareRepository.Products);
        }
    }
}
