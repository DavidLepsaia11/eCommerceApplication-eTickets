using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class AccountsController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

    }
}
