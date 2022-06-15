using Microsoft.AspNetCore.Mvc;

namespace Lanchonete.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
