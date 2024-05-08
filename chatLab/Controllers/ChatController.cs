using Microsoft.AspNetCore.Mvc;

namespace chatLab.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
