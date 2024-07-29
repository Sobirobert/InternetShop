using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.V1
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}