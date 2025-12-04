using Microsoft.AspNetCore.Mvc;

namespace StandBlog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

