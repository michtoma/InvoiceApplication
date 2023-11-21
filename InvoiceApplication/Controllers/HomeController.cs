using Microsoft.AspNetCore.Mvc;

namespace InvoiceApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
